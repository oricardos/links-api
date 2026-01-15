# Links API 🔗

Esta é a API de backend para a aplicação de gerenciamento de links. Desenvolvida com **ASP.NET Core**, a aplicação segue as melhores práticas de desenvolvimento, utilizando uma arquitetura organizada com Controllers, DTOs e persistência de dados.

## 🚀 Tecnologias Utilizadas

* **C# / .NET**: Linguagem e framework principais.
* **ASP.NET Core Web API**: Para a criação dos endpoints RESTful.
* **Entity Framework Core**: ORM para comunicação com o banco de dados.
* **Migrations**: Para controle de versão do esquema do banco de dados.
* **Swagger/OpenAPI**: Para documentação e testes da API.

## 📦 Estrutura do Projeto

O projeto está organizado da seguinte forma:

* `Controllers/`: Lógica de rotas e manipulação de requisições.
* `Models/`: Representação das entidades do banco de dados.
* `DTOs/`: Objetos de transferência de dados para entrada e saída da API.
* `Data/`: Contexto do banco de dados e configurações do EF Core.
* `Middlewares/`: Filtros e tratamentos globais (ex: tratamento de erros).
* `Migrations/`: Histórico de atualizações do banco de dados.

## 🛠️ Como Executar

### Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/download) (versão 7.0 ou superior recomendada).
* Um gerenciador de banco de dados (ex: SQL Server, SQLite, ou outro configurado no `appsettings.json`).

### Passo a passo

1. **Clone o repositório:**
```bash
git clone https://github.com/oricardos/links-api.git

```


2. **Restaure as dependências:**
```bash
dotnet restore

```


3. **Atualize o banco de dados:**
```bash
dotnet ef database update

```


4. **Execute a aplicação:**
```bash
dotnet run

```


*A API estará disponível por padrão em `http://localhost:5000` (ou conforme configurado no seu ambiente).*
<!--
## 📄 Documentação (Swagger)

Com a aplicação rodando, você pode acessar a interface do Swagger para testar os endpoints em:
`http://localhost:YOUR_PORT/swagger`

---
-->
Desenvolvido por [Ricardo](https://github.com/oricardos) 💻
