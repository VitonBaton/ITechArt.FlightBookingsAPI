using AutoMapper;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Web.ViewModels;

namespace ITechArt.FlightBookingsAPI.Web.MappingConfigurations;

public class FlightsProfile : Profile
{
    public FlightsProfile()
    {
        CreateMap<Flight, FlightViewModel>();
        CreateMap<FlightViewModel, Flight>();
    }
}