﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = await DbtContext.Events.AnyAsync(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
            return matches;
        }
    }
}
