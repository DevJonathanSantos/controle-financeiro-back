using ControleFinanceiro.Business.Interfaces.Repository;
using ControleFinanceiro.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repositories;

public class Repository<T> where T : class
{
    private ControleFinanceiroContext _context;
    private DbSet<T> _table;

    public Repository(ControleFinanceiroContext controleFinanceiroContext)
    {
        this._context = controleFinanceiroContext;

        this._table = _context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _table.ToListAsync();
    }

    public virtual async Task<T>  GetById(object id)
    {
        return await _table.FindAsync(id);
    }

    public virtual async Task Add(T obj)
    {
        await _table.AddAsync(obj);
    }

    public virtual async Task Update(T obj)
    {
         _table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
    }

    public virtual async Task Delete(object id)
    {
        T existing = await _table.FindAsync(id);
        _table.Remove(existing);
    }

    public virtual async Task Save()
    {
       await _context.SaveChangesAsync();
    }
}
