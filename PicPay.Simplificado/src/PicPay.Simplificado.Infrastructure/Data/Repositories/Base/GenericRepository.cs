using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PicPay.Simplificado.Domain.Core.Interfaces.Base;
using PicPay.Simplificado.Infrastructure.Data.Context;
using System.Linq.Expressions;

namespace PicPay.Simplificado.Infrastructure.Data.Repositories.Base;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    public GenericRepository(PicPaySimplificadoContext context)
    {
        _dbSet = context.Set<T>();
    }
    public async Task AddAsync(T entity)
    {
       await _dbSet.AddAsync(entity);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.CountAsync(expression);
    }

    public async Task<T> FirstAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetDataAsync(Expression<Func<T, bool>> ? expression = null)
    {
        var query = _dbSet.AsQueryable();

        if (expression != null)
            query = query.Where(expression);

        return await query.ToListAsync();
    }



    public void  Remove(T entity)
    {
        _dbSet.Remove(entity);
       
    }
    public void  Update(T entity)
    {
        _dbSet.Update(entity);
        
    }
}
