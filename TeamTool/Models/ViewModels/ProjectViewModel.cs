using TeamTool.Models.Entities;

namespace TeamTool.Models.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public Team Team { get; set; }
    }
}