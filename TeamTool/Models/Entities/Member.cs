using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamTool.Models.Interfaces;

namespace TeamTool.Models.Entities
{
    public class Member : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Skill { get; set; }
        public string Background { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }

        //public virtual ICollection<Project> Projects { get; set; }
    }
}
