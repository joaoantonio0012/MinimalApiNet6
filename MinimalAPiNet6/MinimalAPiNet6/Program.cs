using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPiNet6.Data;
using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeAplicacao.Interfaces;
using MinimalAPiNet6.ServicosDeAplicacao.ServicosDeAplicacao;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;
using MinimalAPiNet6.ServicosDeRepositorio.Repositorios;
using Newtonsoft.Json;
using Serilog.Context;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("DefautConnectionString");

builder.Services.AddDbContext<Contexto>(option =>option.UseSqlite(conn));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped(serviceType:typeof(_IRepositorioBase<>),implementationType: typeof(_RepositorioBase<>));
builder.Services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();
//builder.Services.AddScoped<IRepositorioCarga, RepositorioCarga>();
//builder.Services.AddScoped<IRepositorioArmazem, RepositorioArmazem>();
 
builder.Services.AddScoped(serviceType:typeof(_IServicosDeAplicacaoBase<>),implementationType: typeof(_ServicoDeAplicacaoBase<>));
builder.Services.AddScoped<IServicoDeAplicacaoEmpresa, ServicoDeAplicacaoEmpresa>();
//builder.Services.AddScoped<IServicoDeAplicacaoArmazem, ServicoDeAplicacaoArmazem>();
//builder.Services.AddScoped<IServicoDeAplicacaoCarga, ServicoDeAplicacaoCarga>();


var app = builder.Build(); 

app.UseSwagger();
app.UseSwaggerUI();
 

app.MapGet("/GetDados", (IServicoDeAplicacaoEmpresa servico) => {

    EmpresaModel empresa = new EmpresaModel {
        NomeFantasia = "Minerio",
        CpfCnpj = "123456789",
        Id = 0,
        RazaoSocial = "Sistemas",
        DataDeCadastro = DateTime.UtcNow.Date,
        
    };

   return new  OkObjectResult( servico.Cadastrar(empresa));

} );

app.MapGet("/GetByName", (string nome, IServicoDeAplicacaoEmpresa servico) => {

     
   return new  OkObjectResult( servico.Recuperar(c => c.NomeFantasia.Contains(nome)));

} );

app.MapDelete("/Excluir", (int Id, IServicoDeAplicacaoEmpresa servico) => {

     
   return new  OkObjectResult( servico.Excluir(Id));

} );

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
