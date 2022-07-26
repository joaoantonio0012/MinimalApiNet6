﻿using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeAplicacao.Interfaces;
 

public interface IServicoDeAplicacaoArmazem : _IServicosDeAplicacaoBase<ArmazemModel>
{
    public decimal TempoMedioDeDescargaPorArmazemId(int armazemId);
    public bool DiminuirUnidadesDeArmazenamento(int armazemId,int unidades);
}
