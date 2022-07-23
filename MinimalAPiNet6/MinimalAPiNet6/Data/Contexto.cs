
using Microsoft.EntityFrameworkCore;
using MinimalAPiNet6.Models;

namespace MinimalAPiNet6.Data;

public class Contexto : DbContext
{

    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        Database.EnsureCreated();

    }
    public DbSet<EmpresaModel> Empresas { get; set; }
    public DbSet<ArmazemModel> Armazens { get; set; }
    public DbSet<CargaModel> Cargas { get; set; }

    protected override void OnModelCreating(ModelBuilder Mb)
    {
        //Mb.Entity<EmpresaModel>().HasKey(e => e.Id);

        //Mb.Entity<EmpresaModel>().Property(e => e.NomeFantasia).HasMaxLength(100);
        //Mb.Entity<EmpresaModel>().Property(e => e.RazaoSocial).HasMaxLength(100);
        //Mb.Entity<EmpresaModel>().Property(e => e.CpfCnpj).HasMaxLength(14);
        //Mb.Entity<EmpresaModel>().Property(e => e.DataDeCadastro);
        //Mb.Entity<EmpresaModel>().Property(e => e.DataDeAlteracao);


        //Mb.Entity<ArmazemModel>().HasKey(e => e.Id);

        //Mb.Entity<ArmazemModel>().Property(e => e.Nome).HasMaxLength(100);
        //Mb.Entity<ArmazemModel>().Property(e => e.Localizacao).HasMaxLength(100);
        //Mb.Entity<ArmazemModel>().Property(e => e.UnidadesDeArmazenamentoMaxima);
        //Mb.Entity<ArmazemModel>().Property(e => e.UnidadesDeArmazenamentoOcupadas);
        //Mb.Entity<ArmazemModel>().Property(e => e.HoraInicioDeRecebimentoDeCarga);
        //Mb.Entity<ArmazemModel>().Property(e => e.HoraFinalDeRecebimentoDeCarga);
        //Mb.Entity<ArmazemModel>().Property(e => e.DataDeCadastro);
        //Mb.Entity<ArmazemModel>().Property(e => e.DataDeAlteracao);


        //Mb.Entity<CargaModel>().HasKey(e => e.Id);
        //Mb.Entity<CargaModel>().Property(e => e.EmpresaId);
        //Mb.Entity<CargaModel>().Property(e => e.ArmazemId);
        //Mb.Entity<CargaModel>().Property(e => e.NomeMotorista).HasMaxLength(100);
        //Mb.Entity<CargaModel>().Property(e => e.CpfMotorista).HasMaxLength(100);
        //Mb.Entity<CargaModel>().Property(e => e.Placa).HasMaxLength(10);
        //Mb.Entity<CargaModel>().Property(e => e.TipoDeCarga);
        //Mb.Entity<CargaModel>().Property(e => e.DataDeAgendamento);
        //Mb.Entity<CargaModel>().Property(e => e.NomePorteiroEntrada).HasMaxLength(100);
        //Mb.Entity<CargaModel>().Property(e => e.CancelaEntrada);
        //Mb.Entity<CargaModel>().Property(e => e.CancelaSaida);
        //Mb.Entity<CargaModel>().Property(e => e.NomePorteiroSaida).HasMaxLength(100);
        //Mb.Entity<CargaModel>().Property(e => e.UnidadesDeArmazenamentoDaCarga);
        //Mb.Entity<CargaModel>().Property(e => e.TempoDePermanenciaDentroDoArmazem);
        //Mb.Entity<CargaModel>().Property(e => e.DataDeCadastro);
        //Mb.Entity<CargaModel>().Property(e => e.DataDeAlteracao);

        //Mb.Entity<CargaModel>().HasOne<ArmazemModel>(e => e.Armazem)
        //    .WithMany(c => c.Cargas)
        //    .HasForeignKey(e => e.ArmazemId);

        //Mb.Entity<CargaModel>().HasOne<EmpresaModel>(e => e.Empresa)
        //    .WithMany(c => c.Cargas)
        //    .HasForeignKey(e => e.EmpresaId);
    }


}
