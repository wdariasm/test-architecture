using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TicketManagement.Application.Contracts;

namespace TicketManagement.Api.Services
{
    public class LoggedInUserService: ILoggedInUserService
    {
        //public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        //{
        //    UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        //}
        public LoggedInUserService()
        {
            UserId = "00000000-0000-0000-0000-000000000000";
        }
        public string UserId { get; }
    }
}
