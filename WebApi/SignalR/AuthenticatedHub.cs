using DanceCoolWebApi.SignalR.Contracts;
using Microsoft.AspNetCore.SignalR;

namespace DanceCoolWebApi.SignalR
{
    public class AuthenticatedHub : Hub<IAuthenticatedContract>
    {
    }
}
