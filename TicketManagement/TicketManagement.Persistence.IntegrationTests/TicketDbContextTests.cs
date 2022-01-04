using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using TicketManagement.Application.Contracts;
using TicketManagement.Domain.Entities;
using Xunit;

namespace TicketManagement.Persistence.IntegrationTests
{
    public class TicketDbContextTests
    {
        private readonly TicketDbContext _ticketDbContext;
        private readonly string _loggedInUserId;

        public TicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TicketDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            var loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _ticketDbContext = new TicketDbContext(dbContextOptions, loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void CreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            _ticketDbContext.Events.Add(ev);
            await _ticketDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
