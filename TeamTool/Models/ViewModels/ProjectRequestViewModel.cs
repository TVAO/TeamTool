using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTool.Models.ViewModels
{
    public class ProjectRequestViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and max {1} characters long.", MinimumLength = 8)]
        public string Name { get; set; }

        [Required]
        [StringLength(400, ErrorMessage = "The {0} must be at least {2} and max {1} characters long.", MinimumLength = 20)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose a team")]
        [DisplayName("Team")]
        public string TeamName { get; set; }
    }
}
