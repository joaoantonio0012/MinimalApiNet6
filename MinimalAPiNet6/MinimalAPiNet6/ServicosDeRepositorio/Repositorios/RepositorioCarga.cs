using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;

namespace MinimalAPiNet6.ServicosDeRepositorio.Repositorios
{
    public class RepositorioCarga : RepositorioBase<CargaModel>, IRepositorioCarga
    {
        public RepositorioCarga(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
