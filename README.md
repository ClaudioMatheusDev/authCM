# 🔐 AuthCM

Sistema Full Stack de autenticação e gerenciamento desenvolvido com **ASP.NET Core**, **Angular**, **Entity Framework Core**, **SQL Server**, **ASP.NET Core Identity** e **JWT (JSON Web Token)**.

O projeto foi desenvolvido com o objetivo de estudar e aplicar conceitos de **arquitetura em camadas**, **autenticação**, **autorização**, **APIs REST**, **segurança**, **persistência de dados** e integração entre **Frontend e Backend**.

---

## 🚀 Tecnologias utilizadas

### Backend

* C#
* ASP.NET Core
* ASP.NET Core Web API
* Entity Framework Core
* ASP.NET Core Identity
* JWT (JSON Web Token)
* SQL Server
* OpenAPI
* Dependency Injection
* CORS

### Frontend

* Angular 19
* TypeScript
* HTML
* CSS
* RxJS
* Angular Router
* Angular Forms

---

## 🏗️ Arquitetura

O backend foi estruturado utilizando separação de responsabilidades em diferentes projetos:

```text
src/
│
├── AuthCM.Api
│   ├── Controllers
│   │   ├── Auth
│   │   ├── Produto
│   │   └── Usuario
│   └── Program.cs
│
├── AuthCM.Application
│   ├── Dtos
│   ├── Interfaces
│   └── Service
│
├── AuthCM.Domain
│   └── Entities
│
├── AuthCM.Infraestructure
│   ├── Data
│   └── Repository
│
├── AuthCM.FrontEnd
│   └── auth-cm
│
└── AuthCM.sln
```

### Responsabilidade das camadas

**AuthCM.Api**

Responsável pela exposição dos endpoints HTTP da aplicação, configuração da API, autenticação JWT, autorização, CORS e injeção de dependências.

**AuthCM.Application**

Contém as regras de aplicação, DTOs, interfaces e serviços responsáveis pela comunicação entre a API e as demais camadas.

**AuthCM.Domain**

Representa o domínio da aplicação e contém as entidades utilizadas pelo sistema.

**AuthCM.Infraestructure**

Responsável pela persistência dos dados, configuração do Entity Framework Core, acesso ao SQL Server e implementação dos repositórios.

**AuthCM.FrontEnd**

Aplicação Angular responsável pela interface e comunicação com a API.

---

# 🔐 Autenticação

A autenticação é realizada utilizando:

**ASP.NET Core Identity + JWT**

O fluxo funciona da seguinte maneira:

```text
Usuário
   │
   ▼
Angular
   │
   │ POST /api/auth/login
   ▼
ASP.NET Core API
   │
   ▼
ASP.NET Core Identity
   │
   │ Validação das credenciais
   ▼
JWT Token
   │
   ▼
Angular
   │
   │ Authorization: Bearer TOKEN
   ▼
Endpoints protegidos
```

Após realizar o login corretamente, a API gera um **JWT Token** que pode ser utilizado para acessar recursos protegidos da aplicação.

O token possui atualmente duração de **2 horas**.

---

# 🔑 Requisitos de senha

O Identity está configurado para exigir:

* mínimo de 8 caracteres;
* pelo menos um número;
* pelo menos uma letra maiúscula;
* pelo menos um caractere especial.

---

# 📡 Endpoints de autenticação

### Registrar usuário

```http
POST /api/auth/register
```

Responsável pela criação de um novo usuário.

### Login

```http
POST /api/auth/login
```

Exemplo:

```json
{
  "email": "usuario@email.com",
  "password": "Senha@123"
}
```

Em caso de autenticação bem-sucedida, a API retorna um JWT:

```json
{
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```

---

# 📦 Módulo de Produtos

A aplicação também possui uma estrutura dedicada ao gerenciamento de produtos.

O módulo segue a separação:

```text
ProdutoController
       │
       ▼
IProdutoService
       │
       ▼
ProdutoService
       │
       ▼
IProdutoRepository
       │
       ▼
ProdutoRepository
       │
       ▼
SQL Server
```

Essa abordagem mantém as responsabilidades separadas e facilita manutenção e evolução do sistema.

---

# 👤 Módulo de Usuários

O gerenciamento de usuários também possui sua própria estrutura:

```text
UsuarioController
       │
       ▼
IUsuarioService
       │
       ▼
UsuarioService
       │
       ▼
IUsuarioRepository
       │
       ▼
UsuarioRepository
```

---

# ⚙️ Configuração

Antes de executar o projeto, configure a conexão com o SQL Server.

Exemplo em:

```text
AuthCM.Api/appsettings.json
```

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=AuthCM;Trusted_Connection=True;TrustServerCertificate=True;"
  },

  "Jwt": {
    "Secret": "SUA_CHAVE_JWT"
  }
}
```

> ⚠️ Em ambientes reais, não armazene chaves JWT ou credenciais diretamente no repositório. Utilize variáveis de ambiente, User Secrets ou um serviço de gerenciamento de secrets.

---

# ▶️ Executando o Backend

Clone o projeto:

```bash
git clone https://github.com/ClaudioMatheusDev/authCM.git
```

Entre no diretório:

```bash
cd authCM/src
```

Restaure as dependências:

```bash
dotnet restore
```

Compile:

```bash
dotnet build
```

Execute a API:

```bash
dotnet run --project AuthCM.Api
```

---

# 🌐 Executando o Frontend

Entre no projeto Angular:

```bash
cd src/AuthCM.FrontEnd/auth-cm
```

Instale as dependências:

```bash
npm install
```

Execute:

```bash
npm start
```

ou:

```bash
ng serve
```

A aplicação Angular será disponibilizada normalmente em:

```text
http://localhost:4200
```

A API já possui uma política CORS configurada para permitir requisições dessa origem durante o desenvolvimento.

---

# 🧠 Conceitos aplicados

Durante o desenvolvimento do projeto foram aplicados conceitos como:

* Arquitetura em camadas
* Separation of Concerns
* Dependency Injection
* Repository Pattern
* Service Layer
* DTOs
* REST API
* Autenticação
* Autorização
* JWT
* ASP.NET Core Identity
* Entity Framework Core
* ORM
* CORS
* Integração Frontend/Backend
* Programação assíncrona

---

# 🎯 Objetivo

O AuthCM é um projeto de estudo voltado ao desenvolvimento Full Stack utilizando tecnologias do ecossistema **.NET + Angular**.

Além da implementação de autenticação, o projeto busca explorar boas práticas de organização de código, segurança, persistência de dados e comunicação entre aplicações frontend e backend.

---

## 👨‍💻 Autor

**Claudio Matheus Ferreira**

Desenvolvedor e estudante de Ciência da Computação.

GitHub: `ClaudioMatheusDev`

---

⭐ Se este projeto foi útil para você ou serviu como referência, considere deixar uma estrela no repositório.
