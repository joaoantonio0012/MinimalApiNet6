using MinimalAPiNet6.Data;
using MinimalAPiNet6.Models;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;
using MinimalAPiNet6.ServicosDeRepositorio.Repositorios;

namespace MinimalAPiNet6.ServicosDeAplicacao.ServicosDeAplicacao
{
    public class ServicoDeAplicacaoEmpresa : _ServicoDeAplicacaoBase<EmpresaModel>, IServicoDeAplicacaoEmpresa
    {
        
        public ServicoDeAplicacaoEmpresa(  Contexto contexto):base(contexto)  
        {

        }
    }
}
