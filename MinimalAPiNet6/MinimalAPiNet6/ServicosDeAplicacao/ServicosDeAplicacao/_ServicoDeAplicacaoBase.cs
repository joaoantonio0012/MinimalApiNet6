using MinimalAPiNet6.Data;
using MinimalAPiNet6.ServicosDeAplicacao.Interfaces;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;
using MinimalAPiNet6.ServicosDeRepositorio.Repositorios;
using System.Linq.Expressions;


namespace MinimalAPiNet6.ServicosDeAplicacao.ServicosDeAplicacao;

public class _ServicoDeAplicacaoBase<T> : _IServicosDeAplicacaoBase<T>, IDisposable where T : class
{
    private readonly _RepositorioBase<T> _RepositorioBase;
     
    public _ServicoDeAplicacaoBase(Contexto contexto)
    {   
        _RepositorioBase = new _RepositorioBase<T>(contexto) ; 
    }

    public void Dispose()
    {
    }

    public T Alterar(T model)
    {
        try
        {

            if (model != null)
            {
                _RepositorioBase.Alterar(model);
                return model;
            }
            else
            {
                throw new Exception("Objeto para alteração vazio!");

            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao Alterar!");
        }
    }

    public T Cadastrar(T Model)
    {
        try
        {

            if (Model != null)
            {
                _RepositorioBase.Cadastrar(Model);
                return Model;
            }
            else
            {
                throw new Exception("Objeto para cadastro vazio!");

            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao Cadastrar!");
        } 
    }

    public bool Excluir(T Model)
    {
        try
        {

            if (Model != null)
            {
                _RepositorioBase.Excluir(Model);
                return true;
            }
            else
            {
                throw new Exception("Objeto para excluir vazio!");

            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir!");
        } 
    }
    public bool Excluir(int Id)
    {
        try
        {

            if (Id >0)
            {
                _RepositorioBase.Excluir(Id);
                return true;
            }
            else
            {
                throw new Exception("Id invalido!");

            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir!");
        }
    }

    public ICollection<T> Recuperar(Expression<Func<T, bool>> predicate)
    {
        try
        {

            return _RepositorioBase.Recuperar (predicate);
              
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao recuperar dados!");
        }

    }
    public T SelecionarPorId(int Id)
    {
        try
        {

            return _RepositorioBase.SelecionarPorId(Id);

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao recuperar dados!");
        }
    }
}
