using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPiNet6.Data;
using Newtonsoft.Json;
using Serilog.Context;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("DefautConnectionString");

builder.Services.AddDbContext<Contexto>(option =>option.UseSqlite(conn));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
 
var app = builder.Build(); 

app.UseSwagger();
app.UseSwaggerUI();
 
app.MapGet("/GetDados", () => "Hello World!");

app.MapPost("/security/create",
        [EnableCors("CorsPolicy")][SwaggerOperation(Summary = "Criar uauário.", Description = "Método responsavel por criar usuário")]
[ProducesResponseType(typeof(  object ), StatusCodes.Status200OK)]
[ProducesResponseType(typeof( object ), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof( object ), StatusCodes.Status500InternalServerError)]
async (string teste ) =>
        {
            using (LogContext.PushProperty("Controller", "UserController"))
            using (LogContext.PushProperty("Payload", JsonConvert.SerializeObject(teste)))
            using (LogContext.PushProperty("Metodo", "Create"))
            {
                return await Task.FromResult (new OkObjectResult("ok"));
            }
        });

app.Run();
