# Sistema Restaurante - Rumo Food

Sistema de gestão de pedidos para restaurante, desenvolvido como prova de conceito para processo seletivo. Permite o cadastro de pedidos, visualização por setor (Cozinha/Copa), atualização de status e histórico de pedidos finalizados.

## Funcionalidades

- **Cadastro de Pedidos** — o funcionário seleciona produtos do cardápio, define mesa, nome do cliente, quantidade e setor (Cozinha ou Copa)
- **Visualização por Setor** — Cozinha e Copa visualizam apenas os pedidos direcionados ao seu setor
- **Atualização de Status** — cada setor pode alterar o status do pedido (Em preparo → Pronto → Entregue)
- **Autenticação** — login com usuário e senha, com geração de token JWT
- **Histórico de Pedidos** — listagem dos pedidos finalizados, com filtro por setor
- **Validação de Formulários** — impede o envio de pedidos com campos vazios

## Tecnologias

**Backend:**
- C# / ASP.NET Core Web API
- Entity Framework Core
- SQLite
- JWT (autenticação)
- Swagger (documentação e testes da API)

**Frontend:**
- HTML5
- CSS3
- JavaScript (Vanilla)

## Arquitetura

- **Frontend:** HTML/CSS/JS consumindo uma API REST
- **Backend:** ASP.NET Core Web API, responsável pelas regras de negócio, autenticação e persistência de dados
- **Banco de dados:** SQLite, acessado via Entity Framework Core

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio ou VS Code
- Extensão **Live Server** (para rodar o frontend no VS Code)

## Como rodar o Backend

```bash
# Clonar o repositório
git clone https://github.com/NOGMarcondes/restaurante-rumo-food.git

# Entrar na pasta da API
cd restaurante-rumo-food\RestauranteAPI

# Instalar a ferramenta de migrations (caso não tenha)
dotnet tool install --global dotnet-ef

# Restaurar os pacotes do projeto
dotnet restore

# Criar o banco de dados (já populado com dados iniciais)
dotnet ef database update

# Rodar a API
dotnet run
```

A API estará disponível em `http://localhost:5285`, com a documentação Swagger em `http://localhost:5285/swagger`.

## Como rodar o Frontend

1. Abra a pasta `RestauranteFront` no VS Code
2. Clique com o botão direito no arquivo `login.html`
3. Selecione **"Open with Live Server"**
4. O navegador abrirá automaticamente em `http://127.0.0.1:5500/login.html`

> **Importante:** a API precisa estar rodando (`dotnet run`) para que o frontend funcione corretamente.

## Usuários de Teste

O sistema possui 3 perfis de acesso, cada um direcionado para uma tela específica conforme seu papel no fluxo do restaurante:

| Perfil | Email | Senha | Acesso |
|---|---|---|---|
| Funcionário | funcionario@rest.com | 123456 | Cadastro de pedidos e histórico |
| Cozinha | cozinha@rest.com | 123456 | Pedidos da cozinha + atualização de status |
| Copa | copa@rest.com | 123456 | Pedidos da copa + atualização de status |

Cada perfil é redirecionado automaticamente para sua tela correspondente após o login, com base na informação contida no token JWT.

O banco já vem populado (via seed) com esses 3 usuários e alguns produtos de exemplo (pratos e bebidas).

## Sobre o desenvolvimento

Esse projeto foi um grande aprendizado. Já tinha experiência com HTML, CSS e JavaScript e estudo C# e SQL na faculdade, mas foi a primeira vez que trabalhei com ASP.NET Core, Web API, Entity Framework Core e migrations — aprendi tudo na prática, junto com a construção do projeto.

A parte mais satisfatória foi entender a comunicação entre frontend e backend via API — requisições, rotas e JSON trafegando entre os dois lados. O Swagger foi essencial para testar cada endpoint antes de integrar com o frontend.

Optei por 3 usuários (Funcionário, Cozinha e Copa) para refletir como o sistema funcionaria na prática: cada setor logado com suas próprias credenciais, acessando apenas as funcionalidades do seu setor.

A maior dificuldade foi nas configurações — entender o "porquê" de cada parte (JWT, CORS, DbContext, migrations) e como elas se conectam.

---

## Autor

Desenvolvido por **Marcos Paulo** como parte do processo seletivo.

[LinkedIn](https://www.linkedin.com/in/marcos-paulo-gon%C3%A7alves-silva-52a50a234/)

Qualquer dúvida ou sugestão, estou à disposição!
