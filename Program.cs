var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("person", () => "Olá pessoa");

app.UseHttpsRedirection();
app.Run();





// Configuração do swagger
// Criando a api:  dotnet new webapi --name person - minimal
// Instalando o swegger:  dotnet add package Swashbuckle.AspNetCore
// dotnet restore
// dotnet run
