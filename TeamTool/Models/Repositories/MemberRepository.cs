using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTool.Models.Entities;
using TeamTool.Models.Interfaces;

namespace TeamTool.Models.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private IContext _context;

        public MemberRepository(IContext context) : base(context)
        {
            _context = context;
        }

        // TODO Not Async 
        public IEnumerable<Member> GetAllEnumerable()
        {
            return _context.Set<Member>().AsEnumerable();
        }
    }

}
