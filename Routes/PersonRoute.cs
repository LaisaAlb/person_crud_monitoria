using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Person.Data;
using Person.Models;

namespace Person.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            var route = app.MapGroup("person");

            route.MapPost("",
            async (PersonRequest req, PersonContext context) =>
            {
                try
                {
                    var person = new PersonModel(req.Name) { Id = Guid.NewGuid() };
                    await context.AddAsync(person);
                    await context.SaveChangesAsync();
                    return Results.Created($"/person/{person.Id}", person);
                }
                catch (Exception ex)
                {
                    app.Logger.LogError(ex, "Erro ao criar pessoa");
                    return Results.Problem("Erro ao criar pessoa");
                }
            });


            route.MapGet("",
            async (PersonContext context) =>
            {
                try
                {
                    var people = await context.People.ToListAsync();
                    return Results.Ok(people);
                }
                catch (Exception ex)
                {
                    app.Logger.LogError(ex, "Erro ao listar pessoas");
                    return Results.Problem("Erro ao listar pessoas");
                }
            });

            route.MapPut("{id:guid}",
             async (Guid id, PersonRequest req, PersonContext context) =>
            {
                try
                {
                    var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

                    if (person == null)
                        return Results.NotFound();

                    person.ChangeName(req.Name);
                    await context.SaveChangesAsync();

                    return Results.Ok(person);
                }
                catch (Exception ex)
                {
                    app.Logger.LogError(ex, "Erro ao atualizar pessoa {Id}", id);
                    return Results.Problem("Erro ao atualizar pessoa");
                }
            });
            
             route.MapDelete("{id:guid}",
             async (Guid id, PersonContext context) =>
            {
                try
                {
                    var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

                    if (person == null)
                        return Results.NotFound();

                    person.SetInactive();
                    await context.SaveChangesAsync();
                    return Results.Ok(person);
                }
                catch (Exception ex)
                {
                    app.Logger.LogError(ex, "Erro ao deletar/desativar pessoa {Id}", id);
                    return Results.Problem("Erro ao deletar/desativar pessoa");
                }
            });
        }
    }
}