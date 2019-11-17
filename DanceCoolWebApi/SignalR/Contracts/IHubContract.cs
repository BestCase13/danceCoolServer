using System.Threading.Tasks;
using DanceCoolDTO;

namespace DanceCoolWebApi.SignalR
{
	public interface IHubContract
    {
        Task UserAdded(UserDTO user);
	}
}
