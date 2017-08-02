using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTool.Models.ViewModels
{
    public class TeamViewModel
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string Contact { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string Background { get; set; }

        public IEnumerable<MemberViewModel> Members { get; set; }
    }
}
