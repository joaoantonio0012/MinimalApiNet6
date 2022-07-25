using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPiNet6.Models;

[Table("Empresa")]

public class EmpresaModel: _ModelBase
{
    public string NomeFantasia { get; set; }
    public string RazaoSocial { get; set; }
    public string CpfCnpj       { get; set; }
    [NotMapped]
    public ICollection <CargaModel>? Cargas { get; set; }
    [NotMapped]
    public ICollection <ArmazemModel>? Armazens { get; set; }

}
