using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TeamTool.Models.ViewModels
{
    public class CreateTeamViewModel
    {
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string Contact { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string Background { get; set; }

        //public IEnumerable<MemberViewModel> Members { get; set; }

        public IEnumerable<SelectListItem> Members { get; set; }
    }
}
