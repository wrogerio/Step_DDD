using System.Collections.Generic;

namespace MWEstacionamentos.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
