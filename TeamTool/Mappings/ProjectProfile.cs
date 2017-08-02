using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TeamTool.Models.Entities;
using TeamTool.Models.ViewModels;

namespace TeamTool.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectRequestViewModel, Project>().ReverseMap();
            CreateMap<Project, ProjectViewModel>().ReverseMap();
        }
    }
}
