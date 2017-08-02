using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTool.Models.Entities;
using TeamTool.Models.Interfaces;

namespace TeamTool.Models.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private IContext _context;

        public TeamRepository(IContext context) : base(context)
        {
            _context = context;
        }

        // TODO Not Async 
        public IEnumerable<Team> GetAllEnumerable()
        {
            return _context.Set<Team>().AsEnumerable();
        }

    }
}
