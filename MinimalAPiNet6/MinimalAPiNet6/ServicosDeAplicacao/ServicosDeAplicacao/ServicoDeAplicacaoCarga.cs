using MinimalAPiNet6.Data;
using MinimalAPiNet6.Models;

namespace MinimalAPiNet6.ServicosDeAplicacao.ServicosDeAplicacao;

public class ServicoDeAplicacaoCarga : _ServicoDeAplicacaoBase<CargaModel>, IServicoDeAplicacaoCarga
{
 
    public ServicoDeAplicacaoCarga(Contexto contexto) : base(contexto)
    {
  
    }
    public bool CargaValidaParaEntradaAltorizada(CargaModel carga)
    {
        // carga esta agendada pra hoje
        if (carga.DataDeAgendamento.Date == DateTime.UtcNow.Date)
        {
            return true;
        }

        return false;
    }
    public bool AlterarCargaParaEntradaAutorizada(int cargaId, string nomePorteiro, int CancelaEntrada)
    {
        if (cargaId == 0)
            return false;
         
        var carga = SelecionarPorId(cargaId);
 
        if (carga != null)
            if (CargaValidaParaEntradaAltorizada(carga))
            {
                carga.CancelaEntrada = CancelaEntrada;
                carga.NomePorteiroEntrada = nomePorteiro;
                carga.DataDeAlteracao = DateTime.UtcNow;
                carga.DataEHoraDeChegada = DateTime.UtcNow;
                Alterar(carga);
                return true;
            }

        return false;
    }
    public bool AlterarCargaParaSaidaAutorizada(int cargaId, string NomePorteiroSaida, int CancelaSaida)
    {
        if (cargaId == 0)
            return false;
         
        var carga = SelecionarPorId(cargaId);
 
        if (carga != null)
            if (CargaValidaParaEntradaAltorizada(carga))
            {
                carga.CancelaSaida = CancelaSaida;
                carga.NomePorteiroSaida = NomePorteiroSaida;
                carga.DataDeAlteracao = DateTime.UtcNow;
                carga.DataEHoraDeSaida = DateTime.UtcNow;

                var tempo =   DateTime.UtcNow.Subtract(carga.DataEHoraDeChegada.Value);
                carga.TempoDePermanenciaDentroDoArmazem = tempo.Hours.ToString();

                Alterar(carga);
                return true;
            }

        return false;
    }
}
