using MinimalAPiNet6.Data;
using MinimalAPiNet6.Models; 

namespace MinimalAPiNet6.ServicosDeAplicacao.ServicosDeAplicacao;

public class ServicoDeAplicacaoArmazem : _ServicoDeAplicacaoBase<ArmazemModel>, IServicoDeAplicacaoArmazem
{
    private readonly IServicoDeAplicacaoCarga _servicoDeAplicacaoCarga;
    public ServicoDeAplicacaoArmazem(IServicoDeAplicacaoCarga servicoDeAplicacaoCarga, Contexto contexto) : base(contexto)
    {
        _servicoDeAplicacaoCarga = servicoDeAplicacaoCarga;
    }

    public decimal TempoMedioDeDescargaPorArmazemId(int armazemId)
    {
        var cargas = _servicoDeAplicacaoCarga.Recuperar(c => c.Id == armazemId && c.CancelaSaida !=null && c.CancelaSaida > 0);

        decimal tempoTotal = 0; 
 
        foreach (var item in cargas)
        {
            decimal tempo =0;
            decimal.TryParse( item.TempoDePermanenciaDentroDoArmazem,out tempo);
            tempoTotal += tempo;
        }

        decimal tempoMedio = tempoTotal > 0 ? (tempoTotal / cargas.Count) : 0;

        return tempoMedio;
    }
}
