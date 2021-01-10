using MWEstacionamentos.Domain.Interfaces.Repositories;
using MWEstacionamentos.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MWEstacionamentos.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly MWContext _context = new MWContext();
        
        public void Create(TEntity obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
