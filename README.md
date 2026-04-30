# API de Ponto de Vendas (PDV) para Padaria

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)](https://swagger.io/)

## 🚀 Sobre o Projeto

Esta é uma **API REST robusta** desenvolvida em .NET Core para gerenciar um sistema completo de Ponto de Vendas (PDV) focado em uma padaria.

O projeto foi estruturado utilizando uma **Arquitetura Multicamadas)**, separando claramente as responsabilidades entre os *Controllers* (Camada de Apresentação/API), a *Lógica de Negócios* (Camada de Serviços/Negócio) e o *Acesso a Dados* (Camada de Dados com Entity Framework). Isso garante um código limpo, desacoplado, manutenível e escalável.

## ✨ Principais Funcionalidades

A API cobre todas as necessidades de um sistema de vendas moderno:

* 🔐 **Autenticação e Autorização:** Sistema completo de registro (`/register`), login (`/login`) e gerenciamento de usuários com **Tokens JWT Bearer**. Inclui refresh/revoke de tokens e gerenciamento de Roles (Cargos).
* 📦 **Gestão de Produtos:** CRUD completo para produtos, incluindo filtros, controle de estoque e paginação.
* 🛒 **Carrinho de Compras:** Funcionalidades para adicionar, remover, consultar itens e alterar a quantidade de produtos no carrinho do usuário.
* 💰 **Gestão de Vendas:** Endpoints para registrar novas vendas e consultar o histórico com filtros avançados (por data, mês, tipo de pagamento).
* 📄 **Paginação:** Implementação de paginação em endpoints de listagem (ex: `/Produto/pagination`) para otimizar a performance em grandes volumes de dados.
* 🛡️ **Validação de Dados:** Uso do **FluentValidation** para garantir a integridade dos dados de entrada (DTOs) de forma limpa e declarativa.
* 🗺️ **Mapeamento de Objetos:** Uso do **AutoMapper** para mapear eficientemente DTOs (Data Transfer Objects) para as Entidades do banco de dados e vice-versa.
* 📖 **Documentação:** API totalmente documentada com **Swagger (Swashbuckle)** para fácil visualização e teste dos endpoints.

## 🛠️ Tecnologias e Dependências

### Stack Principal

* **C#**
* **.NET Core**
* **Entity Framework Core**
* **API REST**
* **MySQL**

### Principais Dependências (NuGet)

* `Pomelo.EntityFrameworkCore.MySql`: Provedor oficial do Entity Framework para MySQL.
* `Swashbuckle.AspNetCore` & `Microsoft.AspNetCore.OpenApi`: Para geração da documentação interativa do Swagger/OpenAPI.
* `FluentValidation`: Para validações de DTOs de forma declarativa e robusta.
* `AutoMapper`: Para mapeamento automático entre DTOs e Entidades.
* `Microsoft.EntityFrameworkCore.Design`: Para comandos de Migrations (Code-First).
* *(O projeto também inclui as dependências de Autenticação JWT do .NET)*

## 💻 Como Executar o Projeto

### Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/pt-br/download) (versão 9.0 ou compatível)
* Um servidor MySQL (local ou em nuvem)
* Um editor de código (ex: [Visual Studio Code](https://code.visualstudio.com/) ou Visual Studio 2022)

### Passos para Instalação

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/VanilsonLins26/ApiPDV
    cd ApiPDV
    ```

2.  **Configure a String de Conexão:**
    * Abra o arquivo `appsettings.json`.
    * Modifique a `ConnectionStrings:DefaultConnection` com os dados do seu banco MySQL (servidor, usuário, senha, nome do banco).

3.  **Aplique as Migrations (Code-First):**
    * O Entity Framework criará a estrutura do banco de dados para você. Rode o comando no terminal na raiz do projeto:
    ```bash
    dotnet ef database update
    ```

4.  **Execute a Aplicação:**
    ```bash
    dotnet run
    ```

5.  **Acesse a Documentação (Swagger):**
    * Abra seu navegador e acesse a URL indicada no terminal (geralmente `https://localhost:PORTA/swagger`).
