using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;

namespace MinimalAPiNet6.ServicosDeRepositorio.Repositorios
{
    public class RepositorioArmazem : RepositorioBase<ArmazemModel>, IRepositorioArmazem
    {
        public RepositorioArmazem(bool saveChanges = true) : base(saveChanges)  
        {

        }
    }
}
