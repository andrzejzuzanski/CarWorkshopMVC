using Application.CarWorkshop;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    internal class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile()
        {
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(cw => cw.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
                {
                    City = src.City,
                    Street = src.Street,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode
                }));

            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(cwd => cwd.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(cwd => cwd.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(cwd => cwd.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(cwd => cwd.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

            CreateMap<CarWorkshopDto, EditCarWorkshopDto>();
        }
    }
}
