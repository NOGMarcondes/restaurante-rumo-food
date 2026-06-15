document.addEventListener('DOMContentLoaded', function() {
    carregarProdutos()
    carregarPedidosDoDia()
})

function carregarProdutos() {
    fetch('http://localhost:5285/api/produtos')
    .then(res => res.json())
    .then(data => {
        var selectProdutos = document.getElementById('TiposProdutos')
        
        data.forEach(produto => {
            var option = document.createElement('option')
            option.value = produto.id
            option.textContent = produto.nomeProduto + ' - R$ ' + produto.valorProduto
            selectProdutos.appendChild(option)
        })
    })
}

function criarPedido() {
    var numMesa = document.getElementById('mesaCliente').value
    var nomeCliente = document.getElementById('nomeCliente').value
    var setorPedido = document.getElementById('setoresCozinha').value
    var produtoId = document.getElementById('TiposProdutos').value
    var quantidade = document.getElementById('quantidadePedidos').value

   if (numMesa === '' || nomeCliente === '' || quantidade === '') {
    alert('Preencha todos os campos!')
    return
}

    

   fetch('http://localhost:5285/api/pedidos', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
        numMesa: Number(numMesa),
        nomeCliente: nomeCliente,
        statusPedido: 'Em preparo',
        dataPedido: new Date().toISOString(),
        usuarioId: 1,
        setorPedido: setorPedido
    })
})
.then(res => res.json())
.then(data => {
    console.log('Pedido criado!', data)

    fetch('http://localhost:5285/api/itempedido', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            pedidoId: data.id,
            produtoId: Number(produtoId),
            quantidade: Number(quantidade)
        })
    })
    .then(res => res.json())
    .then(itemData => {
        console.log('Item adicionado!', itemData)

        var msg = document.getElementById('msgSucesso')
        msg.style.display = 'block'
        setTimeout(() => {
            msg.style.display = 'none'
        }, 3000)
    })
})
}

function carregarPedidosDoDia() {
    fetch('http://localhost:5285/api/pedidos')
    .then(res => res.json())
    .then(data => {
        var tabelaPedidosDoDia = document.getElementById('tabela-pedidosDia')
        tabelaPedidosDoDia.innerHTML = ''

        data.forEach(pedido => {
            var linha = document.createElement('tr')
            linha.innerHTML = `
                <td>${pedido.id}</td>
                <td>${pedido.numMesa}</td>
                <td>${pedido.nomeCliente}</td>
                <td>${pedido.setorPedido}</td>
                <td>${pedido.statusPedido}</td>
            `
            tabelaPedidosDoDia.appendChild(linha)
        })
    })
}
function sair() {
    localStorage.removeItem('token')
    window.location.href = 'login.html'
}