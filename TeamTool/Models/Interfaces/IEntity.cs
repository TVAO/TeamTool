using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTool.Models.Interfaces
{

    /// <summary>
    /// Generic type parameter constraint used to define what entities a accepted by the repositories.
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
