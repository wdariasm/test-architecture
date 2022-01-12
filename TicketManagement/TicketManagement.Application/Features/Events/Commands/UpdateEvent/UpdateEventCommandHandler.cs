using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.EventId);

            if (@event == null)
                throw new NotFoundException(nameof(Event), request.EventId);

            var validator = new UpdateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, @event, typeof(UpdateEventCommand), typeof(Event));

            await _eventRepository.UpdateAsync(@event);

            return Unit.Value;
        }
    }
}
