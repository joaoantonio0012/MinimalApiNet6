using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPiNet6.Models;

 
public abstract class _ModelBase
{ 
    public int Id { get; set; }
    public DateTime DataDeCadastro { get; set; }
    public DateTime DataDeAlteracao { get; set; } 
}
