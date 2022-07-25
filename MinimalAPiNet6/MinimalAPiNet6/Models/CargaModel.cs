using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinimalAPiNet6.Models;

[Table("Carga")]
public class CargaModel : _ModelBase
{

    [JsonIgnore]
    public EmpresaModel Empresa { get; set; }
    public int EmpresaId { get; set; }

    [JsonIgnore]
    public ArmazemModel Armazem { get; set; }
    public int ArmazemId { get; set; }

    public string NomeMotorista { get; set; }
    public string CpfMotorista { get; set; }
    public string Placa { get; set; }
    public int TipoDeCarga { get; set; }
    public DateTime DataDeAgendamento { get; set; }
    public string? NomePorteiroEntrada { get; set; }
    public int? CancelaEntrada { get; set; }
    public string? NomePorteiroSaida { get; set; }
    public int? CancelaSaida { get; set; }
    public int? UnidadesDeArmazenamentoDaCarga { get; set; }
    public int? TempoEstimadoParaDescarregar { get; set; }
    public DateTime? DataEHoraDeChegada { get; set; }
    public DateTime? DataEHoraDeSaida { get; set; }
    public string? TempoDePermanenciaDentroDoArmazem { get; set; }


}
