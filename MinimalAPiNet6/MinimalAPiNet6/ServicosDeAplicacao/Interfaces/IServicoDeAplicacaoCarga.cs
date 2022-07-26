using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeAplicacao.Interfaces;

namespace MinimalAPiNet6.ServicosDeAplicacao.ServicosDeAplicacao
{
    public interface IServicoDeAplicacaoCarga : _IServicosDeAplicacaoBase<CargaModel>
    {
        public bool AlterarCargaParaEntradaAutorizada(int cargaId, string nomePorteiro, int CancelaEntrada);
        public bool AlterarCargaParaSaidaAutorizada(int cargaId, string nomePorteiro, int CancelaSaida);

    }
}
