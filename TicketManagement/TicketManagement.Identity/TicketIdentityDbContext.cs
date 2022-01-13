using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Identity.Models;

namespace TicketManagement.Identity
{
    public class TicketIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public TicketIdentityDbContext(DbContextOptions<TicketIdentityDbContext> options): base(options)
        {
            
        }
    }
}
