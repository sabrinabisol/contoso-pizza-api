# ContosoPizza

Projeto de estudos desenvolvido durante o curso da [Microsoft Learn](https://learn.microsoft.com/pt-br/users/sabrinabisol-5557/achievements/crbwk3p9?ref=https%3A%2F%2F), com o objetivo de aprender os fundamentos de uma API Web usando ASP.NET Core.

## Sobre o projeto

O ContosoPizza é uma API REST simples para cadastrar e gerenciar pizzas. O projeto pratica os conceitos apresentados no curso, como:

- criação de uma aplicação Web com ASP.NET Core;
- organização do código em modelo, serviço e controlador;
- definição de rotas HTTP;
- uso dos verbos `GET`, `POST`, `PUT` e `DELETE`;
- recebimento de dados JSON no corpo das requisições;
- retorno de códigos HTTP, como `200`, `201`, `204` e `404`;
- documentação e testes das requisições.

A API utiliza uma lista em memória como armazenamento. Por isso, não há banco de dados neste exercício e os dados criados, atualizados ou excluídos são perdidos quando a aplicação é reiniciada.

## Tecnologias

- C#
- .NET 9
- ASP.NET Core Web API
- `Microsoft.AspNetCore.OpenApi`

## Estrutura principal

- `Program.cs`: configura os serviços e o pipeline da aplicação.
- `Models/Pizza.cs`: define a entidade pizza, com `Id`, `Name` e `IsGlutenFree`.
- `Controllers/PizzaController.cs`: expõe os endpoints da API.
- `Services/PizzaService.cs`: mantém os dados em memória e executa as operações CRUD.
- `ContosoPizza.http`: contém exemplos de requisições para testar a API.
- `Properties/launchSettings.json`: define as URLs usadas durante o desenvolvimento local.

## Pré-requisitos

- .NET SDK 9 instalado.
- VS Code ou outra ferramenta para executar comandos e enviar requisições HTTP.

Confira a instalação com:

```powershell
dotnet --version
```

## Como executar

Na pasta do projeto, execute:

```powershell
dotnet run
```

A aplicação HTTP ficará disponível em:

```text
http://localhost:5123
```

Também existe um perfil HTTPS em `https://localhost:7165`. Para o primeiro teste, o endereço HTTP é o mais simples.

## Endpoints

| Método | Rota | Descrição |
| --- | --- | --- |
| `GET` | `/pizza` | Lista todas as pizzas |
| `GET` | `/pizza/{id}` | Busca uma pizza pelo ID |
| `POST` | `/pizza` | Cadastra uma nova pizza |
| `PUT` | `/pizza/{id}` | Atualiza uma pizza existente |
| `DELETE` | `/pizza/{id}` | Exclui uma pizza existente |

## Testar pelo navegador

O navegador envia requisições `GET` diretamente pela barra de endereços. Com a aplicação em execução, acesse:

- http://localhost:5123/pizza
- http://localhost:5123/pizza/1

Para `POST`, `PUT` e `DELETE`, use o arquivo `ContosoPizza.http`, o PowerShell, Postman ou Insomnia.

## Testar pelo arquivo HTTP no VS Code

Abra `ContosoPizza.http`. Para aparecer o botão **Send Request**, instale a extensão **REST Client**, de Huachao Mao. Depois, execute cada requisição pelo botão exibido acima dela.

Exemplos:

```http
### Listar pizzas
GET http://localhost:5123/pizza
Accept: application/json

### Buscar pizza por ID
GET http://localhost:5123/pizza/1
Accept: application/json

### Criar pizza
POST http://localhost:5123/pizza
Content-Type: application/json

{
  "name": "Margherita",
  "isGlutenFree": false
}

### Atualizar pizza
PUT http://localhost:5123/pizza/1
Content-Type: application/json

{
  "name": "Classic Italian Atualizada",
  "isGlutenFree": true
}

### Excluir pizza
DELETE http://localhost:5123/pizza/1
```

Respostas esperadas:

- `GET` com sucesso: `200 OK`;
- `POST` com sucesso: `201 Created`;
- `PUT` com sucesso: `204 No Content`;
- `DELETE` com sucesso: `204 No Content`;
- ID inexistente: `404 Not Found`.

## Testar pelo PowerShell

Com a API executando em outro terminal:

```powershell
Invoke-RestMethod http://localhost:5123/pizza -Method Get

Invoke-RestMethod http://localhost:5123/pizza `
  -Method Post `
  -ContentType "application/json" `
  -Body '{"name":"Margherita","isGlutenFree":false}'

Invoke-RestMethod http://localhost:5123/pizza/1 `
  -Method Put `
  -ContentType "application/json" `
  -Body '{"name":"Pizza Atualizada","isGlutenFree":true}'

Invoke-RestMethod http://localhost:5123/pizza/1 -Method Delete
```

## Validar a compilação

Para confirmar que o projeto compila:

```powershell
dotnet build
```

O projeto ainda não possui testes automatizados; neste momento, a validação é feita pela compilação e pelas requisições HTTP descritas acima.
