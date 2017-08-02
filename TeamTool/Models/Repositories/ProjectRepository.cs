using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTool.Models.Entities;
using TeamTool.Models.Interfaces;

namespace TeamTool.Models.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(IContext context) : base(context)
        {
        }
    }
}
