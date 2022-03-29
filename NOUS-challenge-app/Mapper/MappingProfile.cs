using AutoMapper;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.ViewModels;

namespace NOUS_challenge_app.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CleaningPlanModel, CleaningPlanViewModel>().ReverseMap();
        }
    }
}
