var listaProdutos = []

document.addEventListener('DOMContentLoaded', function() {
    carregarProdutos().then(() => {
        carregarPedidos()
    })
})

function carregarProdutos() {
    return fetch('http://localhost:5285/api/produtos')
        .then(res => res.json())
        .then(data => {
            listaProdutos = data
        })
}

function carregarPedidos() {
    fetch('http://localhost:5285/api/pedidos/copa')
    .then(res => res.json())
    .then(data => {
        var tabelaCopa = document.getElementById('tabela-copa')
        tabelaCopa.innerHTML = ''

        data.forEach(pedido => {
            fetch(`http://localhost:5285/api/itempedido/${pedido.id}`)
            .then(res => res.json())
            .then(itens => {

                var nomeProduto = '-'
                var qtd = '-'

                if (itens.length > 0) {
                    var item = itens[0]
                    qtd = item.quantidade

                    var produto = listaProdutos.find(p => p.id === item.produtoId)
                    if (produto) {
                        nomeProduto = produto.nomeProduto
                    }
                }

                var linhaTabelaCopa = document.createElement('tr')
                linhaTabelaCopa.innerHTML = `
                    <td>${pedido.id}</td>
                    <td>${pedido.numMesa}</td>
                    <td>${pedido.nomeCliente}</td>
                    <td>${nomeProduto}</td>
                    <td>${qtd}</td>
                    <td>${pedido.statusPedido}</td>
                    <td>
                        ${pedido.statusPedido === 'Em preparo' 
                        ? `<button class="btnPronto" onclick="atualizarStatus(${pedido.id}, 'Pronto')">Pronto</button>`
                        : pedido.statusPedido === 'Pronto'
                        ? `<button class="btnEntregar" onclick="atualizarStatus(${pedido.id}, 'Entregue')">Entregar</button>`
                        : '—'
                        }
                    </td>
                `
                tabelaCopa.appendChild(linhaTabelaCopa)
            })
        })
    })
}

function atualizarStatus(id, status) {
    fetch(`http://localhost:5285/api/pedidos/${id}?status=${status}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' }
    })
    .then(res => res.json())
    .then(data => {
        console.log('Status atualizado!', data)
        carregarPedidos()
    })
}

function sair() {
    localStorage.removeItem('token')
    window.location.href = 'login.html'
}