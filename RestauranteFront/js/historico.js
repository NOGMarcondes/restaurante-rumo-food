document.addEventListener('DOMContentLoaded', function() {
    carregarHistorico()
})

function carregarHistorico() {
    var urlParametros = new URLSearchParams(window.location.search)
    var setor = urlParametros.get('setor')

    fetch('http://localhost:5285/api/pedidos')
    .then(res => res.json())
    .then(data => {
        var tabelaHistorico = document.getElementById('tabela-historico')
        tabelaHistorico.innerHTML = ''

        data.filter(pedido => {
            if (pedido.statusPedido !== 'Entregue') return false
            if (setor && pedido.setorPedido !== setor) return false
            return true
        })
        .forEach(pedido => {
            var linha = document.createElement('tr')
            linha.innerHTML = `
                <td>${pedido.id}</td>
                <td>${pedido.numMesa}</td>
                <td>${pedido.nomeCliente}</td>
                <td>${pedido.setorPedido}</td>
                <td>${pedido.dataPedido}</td>
                <td>${pedido.statusPedido}</td>
            `
            tabelaHistorico.appendChild(linha)
        })
    })
}


function sair() {
    localStorage.removeItem('token')
    window.location.href = 'login.html'
}