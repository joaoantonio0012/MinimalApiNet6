using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using MinimalAPiNet6.Data;
using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeAplicacao.Interfaces;
using MinimalAPiNet6.ServicosDeAplicacao.ServicosDeAplicacao;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;
using MinimalAPiNet6.ServicosDeRepositorio.Repositorios;
using Newtonsoft.Json;
using Serilog.Context;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//ConnectionString
var conn = builder.Configuration.GetConnectionString("DefautConnectionString");

#region Injeção de dependencias


builder.Services.AddDbContext<Contexto>(option => option.UseSqlite(conn));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped(serviceType: typeof(_IRepositorioBase<>), implementationType: typeof(_RepositorioBase<>));
builder.Services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();
builder.Services.AddScoped<IRepositorioCarga, RepositorioCarga>();
builder.Services.AddScoped<IRepositorioArmazem, RepositorioArmazem>();

builder.Services.AddScoped(serviceType: typeof(_IServicosDeAplicacaoBase<>), implementationType: typeof(_ServicoDeAplicacaoBase<>));
builder.Services.AddScoped<IServicoDeAplicacaoEmpresa, ServicoDeAplicacaoEmpresa>();
builder.Services.AddScoped<IServicoDeAplicacaoArmazem, ServicoDeAplicacaoArmazem>();
builder.Services.AddScoped<IServicoDeAplicacaoCarga, ServicoDeAplicacaoCarga>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Armazém API",
        Version = "v1",
        Description = "Api para controle de armazém",
        TermsOfService = new Uri("https://github.com/joaoantonio0012/MinimalApiNet6"),
        Contact = new OpenApiContact
        {
            Name = "João Antonio Amaro Pereira",
            Email = "joaoantonioamaro@hotmail.com",
            Url = new Uri("https://www.linkedin.com/in/joaoantonioamaro"),
        }
    });

    c.EnableAnnotations();
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

#endregion
// Minimal APi Metodos endpoints
#region Metodos minimal api 


app.MapPost("/CadastrarEmpresa",
[SwaggerOperation(Summary = "Cadastrar Empresa.", Description = "Método responsavel por cadastrar nova empresa")]
(EmpresaModel empresa, IServicoDeAplicacaoEmpresa servico) =>
    {
        var retorno = servico.Cadastrar(empresa);

        if (retorno != null)
            return Results.Ok(retorno);

        return Results.BadRequest("Erro ao cadastrar");
    });

app.MapPost("/CadastrarArmazem",
[SwaggerOperation(Summary = "Cadastrar Armazem.", Description = "Método responsavel por cadastrar novo Armazem")]
(ArmazemModel armazem, IServicoDeAplicacaoArmazem servico) =>
    {
        var retorno = servico.Cadastrar(armazem);

        if (retorno != null)
            return Results.Ok(retorno);

        return Results.BadRequest("Erro ao cadastrar");
    });

app.MapPost("/CadastrarCarga",
[SwaggerOperation(Summary = "Cadastrar Carga.", Description = "Método responsavel por cadastrar nova carga")]
(CargaModel carga, IServicoDeAplicacaoCarga servico) =>
    {
        var retorno = servico.Cadastrar(carga);

        if (retorno != null)
            return Results.Ok(retorno);

        return Results.BadRequest("Erro ao cadastrar");
    });

app.MapGet("/ConferirCargaNaEntradaDoArmazem",
[SwaggerOperation(Summary = "Localizar Carga.", Description = "Método responsavel por verificar existencia de carga cadastrada no sistema")]
(string placa, string cpfcnpjMotorista, int tipoDeCarga, IServicoDeAplicacaoCarga servico) =>
    {
        var retorno = servico.Recuperar(c => c.Placa.Equals(placa) && c.CpfMotorista.Equals(cpfcnpjMotorista) && c.TipoDeCarga.Equals(tipoDeCarga)).FirstOrDefault();

        if (retorno != null)
            return Results.Ok(retorno);

        return Results.BadRequest("Carga não encontrada no sistema");
    });

app.MapGet("/GetCarga",
[SwaggerOperation(Summary = "Localizar Carga.", Description = "Método responsavel pesquisar carga por Id")]
(int cargaId, IServicoDeAplicacaoCarga servico) =>
    {
        var retorno = servico.SelecionarPorId(cargaId);

        if (retorno != null)
            return Results.Ok(retorno);

        return Results.BadRequest("Carga não encontrada no sistema");
    });

app.MapPut("/AlterarCargaParaEntradaAutorizada",
[SwaggerOperation(Summary = "Autorizar abrir cancela de entrada.", Description = "Método responsável por marcar como cancela de entrada ok")]
(int cargaId, string NomePorteiroEntrada, int CancelaEntrada, IServicoDeAplicacaoCarga servico) =>
    {
        var ok = servico.AlterarCargaParaEntradaAutorizada(cargaId, NomePorteiroEntrada, CancelaEntrada);

        if (ok)
            return Results.Ok("Carga autorizada para entrar");

        return Results.BadRequest("Carga não autorizada");
    });


app.MapPut("/AlterarCargaParaSaidaAutorizada",
[SwaggerOperation(Summary = "Autorizar abrir cancela de saída.", Description = "Método responsável por marcar como cancela de saída ok e atualizar tempo de descarga")]
(int cargaId, string NomePorteiroSaida, int CancelaSaida, IServicoDeAplicacaoCarga servico) =>
    {
        var ok = servico.AlterarCargaParaSaidaAutorizada(cargaId, NomePorteiroSaida, CancelaSaida);

        if (ok)
            return Results.Ok("Carga autorizada para sair");

        return Results.BadRequest("Carga não autorizada");
    });

app.MapGet("/TempoMedioDeDescargaPorArmazemId",
[SwaggerOperation(Summary = "Retorna tempo medio de descarga.", Description = "Método responsável por retornar tempo medio de descarga de determinado armazém")]
(int armazemId, IServicoDeAplicacaoArmazem servico) =>
    {
        var tempoMedio = servico.TempoMedioDeDescargaPorArmazemId(armazemId);

        return Results.Ok(tempoMedio != 0 ? $"Tempo medio para descarga {tempoMedio} horas" : "Armazem não contém cargas finalizadas no momento");

    });

#endregion 
app.Run();
