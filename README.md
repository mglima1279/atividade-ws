# CRUD agencias

Projeto desenvolvido sem consulta à internet e no período aproximado de 50 minutos.


# Tecnologias

ASP.NET, C#, Pomelo.EntityFrameworkCore.MySql, MySql database, XAMPP servidor local para o MySql.

# Arquitetura de pastas do projeto
```
├── Backend/
│   ├── Controllers/
│   │   └── AgenciaController.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Entities/
│   │   └── Agencia.cs
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── Repositories/
│   │   └── AgenciaRepository.cs
│   ├── Backend.csproj
│   ├── Program.cs
│   └── appsettings.json
├── Frontend/
│   ├── assets/
│   │   ├── css/
│   │   │   └── root.css
│   │   └── js/
│   │       ├── create.js
│   │       ├── edit.js
│   │       └── list.js
│   ├── view/
│   │   ├── create.html
│   │   ├── edit.html
│   │   └── list.html
│   └── index.html
├── .gitattributes
├── .gitignore
└── Backend.slnx
```

# Como usar

1. Ativar o MySql no XAMPP e configurar sua porta para 3306;
2. Criar o banco e as tabelas no MySql Workbench;
```
DROP DATABASE IF EXISTS `dbfinanceiro`;

CREATE DATABASE `dbfinanceiro`;

USE `dbfinanceiro`;

CREATE TABLE `agencias`(
	`id` INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `name` VARCHAR(100) NOT NULL,
    `city` VARCHAR(100) NOT NULL,
    `state` VARCHAR(2) NOT NULL
);
```
3. Execute a solução para inicializar o servidor;
4. Abra o arquivo `index.html` para usufruir da aplicação;

# API Endpoints

A rota base para todos os endpoints listados abaixo é: `api/agencias`

## Estrutura do Objeto (Agencia)

Sempre que a API esperar ou retornar um objeto do tipo `Agencia`, a estrutura do JSON seguirá o padrão abaixo:

```json
{
  "id": 1, 
  "name": "Nome da Agência", // String (Máx. 100 caracteres)
  "city": "Nome da Cidade",  // String (Máx. 100 caracteres)
  "state": "UF"              // String (Máx. 2 caracteres)
}

```

> **Nota:** O campo `id` é gerado automaticamente pelo banco de dados (Identity) no momento da criação.

## Endpoints

### 1. Criar Nova Agência

Cadastra uma nova agência no banco de dados.

-   **Rota:** `POST /api/agencias`
    
-   **Request Body (JSON):**
    
    JSON
    
    ```
    {
      "name": "Agência Central",
      "city": "Salvador",
      "state": "BA"
    }
    
    ```
    
-   **Responses:**
    
    -   **`201 Created`**: Retorna a agência criada com o seu ID gerado. Inclui o Header `Location` apontando para a URI do novo recurso (ex: `/api/agencias/1`).
        
    -   **`400 Bad Request`**: Se houver falha na validação dos dados (ex: strings que excedam o limite de caracteres).
        

### 2. Buscar Agência por ID

Retorna os detalhes de uma agência específica.

-   **Rota:** `GET /api/agencias/{id}`
    
-   **Parâmetros de Rota:**
    
    -   `id` _(int)_: O ID identificador da agência.
        
-   **Request Body:** Nenhum.
    
-   **Responses:**
    
    -   **`200 OK`**: Retorna o objeto JSON da agência encontrada.
        
    -   **`404 Not Found`**: Retorna o texto da exceção caso o ID não exista no sistema (tratado via repositório).
        
    -   **`400 Bad Request`**: Retorna o texto da exceção para outros tipos de erro genéricos.
        

### 3. Listar Todas as Agências

Retorna todas as agências cadastradas.

-   **Rota:** `GET /api/agencias`
    
-   **Request Body:** Nenhum.
    
-   **Responses:**
    
    -   **`200 OK`**: Retorna um array de objetos JSON.
        
        JSON
        
        ```
        [
          {
            "id": 1,
            "name": "Agência Central",
            "city": "Salvador",
            "state": "BA"
          },
          {
            "id": 2,
            "name": "Agência Litoral",
            "city": "Santos",
            "state": "SP"
          }
        ]
        
        ```
        

### 4. Atualizar Agência Existente

Substitui os dados de uma agência existente através do ID fornecido.

-   **Rota:** `PUT /api/agencias/{id}`
    
-   **Parâmetros de Rota:**
    
    -   `id` _(int)_: O ID da agência a ser atualizada.
        
-   **Request Body (JSON):**
    
    JSON
    
    ```
    {
      "id": 1,
      "name": "Agência Central Atualizada",
      "city": "Salvador",
      "state": "BA"
    }
    
    ```
    
-   **Responses:**
    
    -   **`200 OK`**: Retorna o objeto JSON da agência atualizada com sucesso.
        
    -   **`404 Not Found`**: Retorna o erro se o ID não for localizado no banco de dados.
        
    -   **`400 Bad Request`**: Retorna o erro para outras falhas na validação ou no processamento da requisição.
        

### 5. Deletar Agência

Remove uma agência do sistema.

-   **Rota:** `DELETE /api/agencias/{id}`
    
-   **Parâmetros de Rota:**
    
    -   `id` _(int)_: O ID da agência a ser removida.
        
-   **Request Body:** Nenhum.
    
-   **Responses:**
    
    -   **`204 No Content`**: Removido com sucesso. A resposta não possui corpo.
