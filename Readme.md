# Person API

Projeto didático em .NET 9 (Minimal API) para fins de monitoria na faculdade. Simula operações CRUD simples sobre uma entidade Person usando Entity Framework Core e documentação Swagger.

> Aviso: projeto para estudo — não pronto para produção.

## Objetivo
- Demonstrar uso de Minimal APIs no .NET.
- Integrar EF Core (SQLite) para persistência.
- Documentar API com Swagger (Swashbuckle).
- Mostrar boas práticas básicas: DTOs, tratamento de exceções, logging.

## Requisitos
- .NET 9 SDK
- dotnet-ef (opcional, para migrations)
- SQLite (arquivo local)

## Pacotes usados (exemplos)
- Swashbuckle.AspNetCore
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design (opcional)

Instalar via terminal (pasta do projeto):
```powershell
dotnet add package Swashbuckle.AspNetCore
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef   # opcional
dotnet restore
```

## Configuração rápida
Adicione uma connection string em `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=person.db"
  }
}
```

Registre o DbContext em `Program.cs` (exemplo):
```csharp
// filepath: c:\Users\Dell\OneDrive - Educacional\Laísa\Cursos\c#\Person\Program.cs
// ...existing code...
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Person.Data.PersonContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```

Observação: remova ou substitua qualquer chamada não padrão como `AddOpenApi()` pelo padrão `AddEndpointsApiExplorer()` + `AddSwaggerGen()`.

## Migrations / Banco
Criar migration e atualizar banco:
```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Executar
```powershell
dotnet run
```
Swagger UI (quando em Development):
https://localhost:{porta}/swagger

## Endpoints (resumo)
Base: /person

- POST /person  
  Body: { "name": "Nome" } — cria pessoa
- GET /person  
  Lista todas as pessoas
- PUT /person/{id}  
  Body: { "name": "Novo Nome" } — atualiza
- DELETE /person/{id}  
  Marca como inativa (implementação didática)

Exemplo curl:
```bash
https://localhost:5001/person
```

## Boas práticas recomendadas
- Separar responsabilidades: Controllers/Routes, Services (business logic), Repositories (acesso a dados).
- Usar DTOs/Requests/Responses e validação (DataAnnotations ou FluentValidation).
- Usar middleware global para tratamento de exceções em vez de try/catch repetidos.
- Ter campo booleano `IsActive` ao invés de sobrescrever `Name` para "desativado".
- Adicionar testes unitários/integration tests (usar EF InMemory para testes).

## Observações finais
Projeto criado como material de monitoria universitária — objetivo é aprendizado e experimentação. Contribuições são bem-vindas; abra issues ou PRs com melhorias.

### 🪪 Licença
Este projeto está licenciado sob a [Licença MIT](LICENSE).

---

### 🌐 Conecte-se comigo

<p align="center">
  <a href="https://www.linkedin.com/in/laisaalbdev/">
    <img src="https://img.shields.io/badge/LinkedIn-ffffff?style=for-the-badge&logo=linkedin&logoColor=white" alt="LinkedIn">
  </a>
  &nbsp;&nbsp;
  <a href="https://github.com/LaisaAlb">
    <img src="https://img.shields.io/badge/GitHub-ffffff?style=for-the-badge&logo=github&logoColor=white" alt="GitHub">
  </a>
</p>
