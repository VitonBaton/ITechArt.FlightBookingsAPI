using AutoMapper;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Web.Models;

namespace ITechArt.FlightBookingsAPI.Web.MappingConfigurations;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<RegistrationViewModel, User>();
        CreateMap<UserViewModel, User>();
        CreateMap<User, UserViewModel>();
    }
}