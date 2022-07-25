using Microsoft.EntityFrameworkCore;
using MinimalAPiNet6.Data;
using MinimalAPiNet6.ServicosDeRepositorio.Interfaces;
using System.Linq.Expressions;


namespace MinimalAPiNet6.ServicosDeRepositorio.Repositorios;

public class _RepositorioBase<T> : _IRepositorioBase<T>, IDisposable where T : class
{
    public bool _SaveChanges = true;
    protected Contexto _Contexto;
    protected DbSet<T> dbSet;

    public _RepositorioBase(Contexto contexto )
    {
        _Contexto = contexto;
        dbSet = _Contexto.Set<T>(); 
    }

    public void Dispose()
    { 
        _Contexto.Dispose();    
    }

    public T Alterar(T model)
    {

        _Contexto.Entry(model).State = EntityState.Modified;

        if (_SaveChanges)
        {
            _Contexto.SaveChanges();
            return model;
        }
        return null;

    }

    public T Cadastrar(T Model)
    { 
        _Contexto.Set<T>().Add(Model);

        if (_SaveChanges)
        {
            _Contexto.SaveChanges();
            return Model;
        }
        return null;

    }

    public bool Excluir(T Model)
    {
        _Contexto.Set<T>().Remove(Model);

        if (_SaveChanges)
        {
            _Contexto.SaveChanges();
            return true;
        }
        return false;
    }
    public bool Excluir(int Id)
    {
        var obj = SelecionarPorId(Id);

        return Excluir(obj);
    }

    public ICollection<T> Recuperar(Expression<Func<T, bool>> predicate)
    {
        return _Contexto.Set<T>().Where(predicate).ToList();

    } 
    public T SelecionarPorId(int id)
    {
        return _Contexto.Set<T>().Find( id); 
    }
}
