using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTool.Models.Interfaces;

namespace TeamTool.Models.Entities
{
    public class Team : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Background { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
