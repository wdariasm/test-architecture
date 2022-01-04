using AutoMapper;
using TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using TicketManagement.Application.Features.Events.Commands.CreateEvent;
using TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using TicketManagement.Application.Features.Events.Queries.GetEventsList;
using TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
