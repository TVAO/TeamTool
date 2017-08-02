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
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamViewModel>().ReverseMap();
            CreateMap<Team, CreateTeamViewModel>().ReverseMap();
        }
    }
}
