using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTool.Models.Entities
{
    /// <summary>
    /// Association table (join) between Team and Member entity (many-to-many)
    /// The joined table is used to avoid storing duplicate values, causing excessive calculations for every query run against it. 
    /// </summary>
    public class TeamMember
    {
        public int TeamId { get; set; }
        public int MemberId { get; set; }
        public Team Team { get; set; }
        public Member Member { get; set; }
    }
}
