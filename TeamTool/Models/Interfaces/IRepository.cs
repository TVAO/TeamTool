using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTool.Models.Interfaces
{
    public interface IRepository<T> : IDisposable
    {

        Task<int> CreateAsync(T entity);

        Task<T> FindAsync(int id);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);

        Task<IQueryable<T>> GetAllAsync();
    }
}
