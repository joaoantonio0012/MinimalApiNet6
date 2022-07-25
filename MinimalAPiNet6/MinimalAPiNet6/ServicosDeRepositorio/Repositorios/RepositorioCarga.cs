using MinimalAPiNet6.Data;
using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;

namespace MinimalAPiNet6.ServicosDeRepositorio.Repositorios;


public class RepositorioCarga : _RepositorioBase<CargaModel>, IRepositorioCarga
{
    public RepositorioCarga(Contexto contexto) : base(contexto)
    {

    }

}
