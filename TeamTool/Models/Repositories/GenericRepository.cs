using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTool.Models.Interfaces;

namespace TeamTool.Models.Repositories
{

    /// <summary>
    /// Generic repository for CRUD operations implemented by all repositories as an abstract class.
    /// Virtual keyword used to indicate that default interface signature may be overriden so that CRUD operations are async.
    /// </summary>
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private IContext _context;

        public GenericRepository(IContext context)
        {
            _context = context;
        }

        public virtual async Task<int> CreateAsync(T entity) // Returns ID of entity
        {
            var result = await _context.Set<T>().AddAsync(entity);
            if (await _context.SaveChangesAsync() > 1)
            {
                return -1; // Error 
            }
            return result.Entity.Id;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = _context.Set<T>().First(e => e.Id == id);
                _context.Set<T>().Remove(entity);
                return await _context.SaveChangesAsync() == 1; // True if success 
            }
            catch (InvalidOperationException e)
            {
                // TODO Logging 
                return false; 
            }
        }

        public virtual async Task<T> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0; // True if success 
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }

}
