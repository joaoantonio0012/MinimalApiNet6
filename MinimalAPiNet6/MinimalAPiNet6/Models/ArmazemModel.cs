using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPiNet6.Models;

[Table("Armazem")]
public class ArmazemModel : _ModelBase
{
    public string Nome { get; set; }
    public long UnidadesDeArmazenamentoMaxima { get; set; }
    public long UnidadesDeArmazenamentoOcupadas { get; set; }
    public string Localizacao { get; set; }
    public int HoraInicioDeRecebimentoDeCarga { get; set; } = 9;
    public int HoraFinalDeRecebimentoDeCarga { get; set; } = 19;

    public ICollection <CargaModel>? Cargas { get; set; }
}
