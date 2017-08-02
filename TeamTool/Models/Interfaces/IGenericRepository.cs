using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTool.Models.Interfaces
{
    public interface IGenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        
    }
}
