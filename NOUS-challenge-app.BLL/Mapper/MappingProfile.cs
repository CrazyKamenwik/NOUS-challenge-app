using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.DAL.Entities;

namespace NOUS_challenge_app.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CleaningPlanEntity, CleaningPlanModel>().ReverseMap();
        }
    }
}
