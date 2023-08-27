using ControleFinanceiro.Core.Interfaces;
using System.Security.Principal;

namespace ControleFinanceiro.Business.Interfaces.Repository;

public interface IRepository<T> where T : class, IEntity
{
    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(object id);

    Task Add(T obj);

    Task Update(T obj);

    Task Delete(object id);

    Task Save();
}
