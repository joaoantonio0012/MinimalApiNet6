using MinimalAPiNet6.Data;
using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;

namespace MinimalAPiNet6.ServicosDeRepositorio.Repositorios;

public class RepositorioArmazem : _RepositorioBase<ArmazemModel>, IRepositorioArmazem
{
    public RepositorioArmazem(Contexto contexto) : base(contexto)
    {

    }
}
