using AutoMapper;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Web.ViewModels;

namespace ITechArt.FlightBookingsAPI.Web.MappingConfigurations;

public class TicketsProfile : Profile
{
    public TicketsProfile()
    {
        CreateMap<Ticket, TicketViewModel>();
        CreateMap<TicketViewModel, Ticket>();
        CreateMap<IGrouping<Guid, Ticket>, TicketsWithSummaryViewModel>()
            .ForMember(model => model.FlightId,
                expression => expression.MapFrom(tickets => tickets.Key))
            .ForMember(model => model.Tickets,
                expression => expression.MapFrom(tickets => tickets));
    }
}