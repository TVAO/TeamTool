using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTool.Models.Interfaces;

namespace TeamTool.Models.Entities
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public Team Team { get; set; } 
    }
}
