using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.CityDTOs;
using DTOLayer.DTOs.ContactDTOs;
using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;

namespace TraversalCore.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();
            CreateMap<AppUserRegisterDTO,AppUser>().ReverseMap();
            CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();
            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();
            CreateMap<AnnouncementUpdateDTO, Announcement>().ReverseMap();
            CreateMap<SendMessageDTO, ContactUs>().ReverseMap();
            CreateMap<ReservationAddDTO,Reservation>().ReverseMap();
            CreateMap<ReservationListDTO, Reservation>().ReverseMap();
        }
    }
}
