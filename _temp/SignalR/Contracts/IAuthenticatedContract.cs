using System.Threading.Tasks;
using DanceCoolDTO;

namespace DanceCoolWebApi.SignalR.Contracts
{
    public interface IAuthenticatedContract
    {
        Task UserAuthorized(int userId);
        Task UserRegistered(int userId);
        Task UserLoggedOut(int userId);
    }
}
