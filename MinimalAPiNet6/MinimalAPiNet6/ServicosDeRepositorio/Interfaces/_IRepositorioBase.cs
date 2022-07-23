using System.Linq.Expressions;

namespace MinimalAPiNet6.ServicosDeRepositorio.Interfaces;

public interface _IRepositorioBase<T> where T : class
{
    public T Cadastrar(T model);
    public T Alterar(T model);
    public bool Excluir(T id);
    public bool Excluir(int id);
    public T SelecionarPorId(int id); 
    public ICollection<T> Recuperar(Expression<Func<T, bool>> predicate);
}
