using AutoMapper;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Web.ViewModels;

namespace ITechArt.FlightBookingsAPI.Web.MappingConfigurations;

public class TicketsProfile : Profile
{
    public TicketsProfile()
    {
        CreateMap<FlightTicketType, FlightTicketTypeViewModel>();
        CreateMap<FlightTicketTypeViewModel, FlightTicketType>();
    }
}