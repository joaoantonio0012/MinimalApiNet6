using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;

namespace MinimalAPiNet6.ServicosDeRepositorio.Repositorios
{
    public class RepositorioEmpresa : RepositorioBase<EmpresaModel>, IRepositorioEmpresa
    {

        public RepositorioEmpresa(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
