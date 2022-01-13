using System;
using System.Threading.Tasks;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Models.Authentication;

namespace TicketManagement.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
