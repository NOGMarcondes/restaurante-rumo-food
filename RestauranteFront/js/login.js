function decodificarToken(token) {
    var base64 = token.split('.')[1]
    var decoded = atob(base64)
    return JSON.parse(decoded)
}

function fazerLogin() {
    var valorEmail = document.getElementById('email').value
    var valorSenha = document.getElementById('password').value
    var msg = document.getElementById('msgLogin')

    fetch('http://localhost:5285/api/usuarios/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ 
            name: "",
            email: valorEmail, 
            senha: valorSenha,
            perfil: ""
        })
    })
    .then(res => {
        if (res.ok) {
            return res.json()
        } else {
            return { token: null }
        }
    })
    .then(data => {
        if (data.token) {
            msg.style.display = 'block'
            msg.style.color = 'green'
            msg.textContent = 'Login realizado com sucesso!'

            localStorage.setItem('token', data.token)
            var payload = decodificarToken(data.token)

            var role = payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']

            setTimeout(() => {
                if(role === 'Funcionario') {
                    window.location.href = 'funcionario.html'
                } else if(role === 'Cozinha') {
                    window.location.href = 'cozinha.html'
                } else if(role === 'Copa') {
                    window.location.href = 'copa.html'
                }
            }, 1000)
        } else {
            msg.style.display = 'block'
            msg.style.color = 'red'
            msg.textContent = 'Usuário ou senha inválidos'
        }
    })
}

function limparLogin() {
    document.getElementById('email').value = ''
    document.getElementById('password').value = ''
}