using System.Linq.Expressions;

namespace PicPay.Simplificado.Domain.Core.Interfaces.Base;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);

    void Remove(T entity);

    void Update(T entity);

    Task<T> GetByIdAsync(int id);

    Task<T> FirstAsync(Expression<Func<T, bool>> expression);

    Task<int> CountAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> GetDataAsync(Expression<Func<T, bool>>? expression = null);
}