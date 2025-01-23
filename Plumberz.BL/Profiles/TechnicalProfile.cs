using AutoMapper;
using Plumberz.BL.ViewModels.Technicals;
using Plumberz.Core.Entities.Technicals;

namespace Plumberz.BL.Profiles
{
    public class TechnicalProfile : Profile
    {
        public TechnicalProfile()
        {
            CreateMap<Technical, TechListItem>().ReverseMap();
            CreateMap<TechnicalCreateVM, Technical>()
                .ForMember(x => x.ImageUrl, x => x.MapFrom(y => y.Image));
        }
    }
}
