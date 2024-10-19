# 🚀 WebAPI Funcionários 🚀

Esta é uma API RESTful para gerenciamento de funcionários, desenvolvida com ASP.NET Core. A API permite realizar operações CRUD (Criar, Ler, Atualizar e Excluir) em registros de funcionários, utilizando o **Repository Pattern** para uma melhor organização e separação de responsabilidades, e JWT para autenticação e autorização de acesso.

## 📑 Índice
- [Funcionalidades](#-funcionalidades)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Estrutura da API](#-estrutura-da-api)
  - [Endpoints](#-endpoints)
  - [Modelo de Funcionário](#-modelo-de-funcionário)
- [Enumerações](#-enumerações)
  - [DepartamentoEnum](#departamentoenum)
  - [TurnoEnum](#turnoenum)
- [Configuração](#-configuração)
  - [Pré-requisitos](#-pré-requisitos)
  - [Como Executar](#-como-executar)
- [Contribuições](#-contribuições)
  
## 📋 Funcionalidades

- **Listar todos os funcionários**
- **Buscar funcionário por ID**
- **Adicionar novo funcionário**
- **Atualizar informações de funcionário**
- **Inativar funcionário**
- **Excluir funcionário**

## 🛠️ Tecnologias Utilizadas

- C#
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [SQL Server](https://www.microsoft.com/sql-server)
- [Swagger](https://swagger.io/tools/swagger-ui/) para documentação da API

## 📂 Estrutura da API


### 🔗 Endpoints

| Método | Endpoint                             | Descrição                                     |
|--------|--------------------------------------|-----------------------------------------------|
| GET    | `/api/funcionario`                  | Retorna a lista de todos os funcionários.    |
| GET    | `/api/funcionario/{id}`             | Retorna um funcionário específico pelo ID.    |
| POST   | `/api/funcionario`                  | Adiciona um novo funcionário.                 |
| PUT    | `/api/funcionario/inativaFuncionario` | Inativa um funcionário pelo ID.               |
| PUT    | `/api/funcionario`                  | Atualiza um funcionário existente.            |
| DELETE | `/api/funcionario`                  | Exclui um funcionário pelo ID.                |

### 👤 Modelo de Funcionário

```csharp
public class FuncionarioModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DepartamentoEnum Departamento { get; set; }
    public bool Ativo { get; set; }
    public TurnoEnum Turno { get; set; }
    public DateTime DataDeCriacao { get; set; }
    public DateTime DataDeAlteracao { get; set; }
}
```
## 📊 Enumerações

### DepartamentoEnum
```csharp
public enum DepartamentoEnum
{
    RH,
    Financeiro,
    Compras,
    Atendimento,
    Zeladoria
}
```

### TurnoEnum
```csharp
public enum TurnoEnum
{
    Manha,
    Tarde,
    Noite
}
```

## 🔐 Autenticação com JWT

A API utiliza **JSON Web Token (JWT)** para autenticação e autorização de acesso a determinados endpoints. Abaixo estão as instruções de como configurar e utilizar o JWT.

### 🚪 Endpoints de Autenticação

| Método | Endpoint         | Descrição                        |
|--------|------------------|----------------------------------|
| POST   | `/api/auth/login`| Autentica o usuário e gera o JWT.|

### Como usar JWT na API

1. **Autenticação**:
   - O cliente deve enviar uma solicitação `POST` ao endpoint `/api/auth/login` com as credenciais do usuário.
   - Se a autenticação for bem-sucedida, a API retornará um token JWT.

2. **Autorização**:
   - Após receber o token, o cliente deve incluir o JWT no cabeçalho das solicitações subsequentes para acessar os endpoints protegidos.
   - Exemplo de cabeçalho com o token JWT:
     ```http
     Authorization: Bearer {token}
     ```

3. **Proteção de Endpoints**:
   - Alguns endpoints exigem autenticação para serem acessados. Esses endpoints estarão protegidos e retornarão erro `401 Unauthorized` caso o token JWT não seja fornecido ou seja inválido.


## ⚙️ Configuração

### 🔧 Pré-requisitos
- .NET SDK instalado
- SQL Server configurado

### 🚀 Como Executar
1. Clone o repositório:

    ```bash
    git clone <URL_DO_REPOSITORIO>
    ```

2. Navegue até o diretório do projeto:

    ```bash
    cd WebAPI_Funcionarios
    ```

3. Instale as dependências:

    ```bash
    dotnet restore
    ```

4. Execute a aplicação:

    ```bash
    dotnet run
    ```

5. Acesse a documentação da API via Swagger em `https://localhost:<PORTA>/swagger`.

## 🤝 Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir um issue ou enviar um pull request.
