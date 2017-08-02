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
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<MemberViewModel, Member>().ReverseMap();
            CreateMap<CreateMemberViewModel, Member>().ReverseMap();
        }
    }
}
