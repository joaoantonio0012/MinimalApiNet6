﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinimalAPiNet6.Models;

[Table("Empresa")]

public class EmpresaModel: _ModelBase
{
    public string NomeFantasia { get; set; }
    public string RazaoSocial { get; set; }
    public string CpfCnpj       { get; set; }
    [JsonIgnore ]
    public ICollection <CargaModel>? Cargas { get; set; }
    [JsonIgnore]

    public ICollection <ArmazemModel>? Armazens { get; set; }

}
