using MinimalAPiNet6.Data;
using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;

namespace MinimalAPiNet6.ServicosDeRepositorio.Repositorios;

public class RepositorioEmpresa : _RepositorioBase<EmpresaModel>, IRepositorioEmpresa
{ 
    public RepositorioEmpresa(  Contexto  contexto ):base(contexto) 
    { 
    }
}
