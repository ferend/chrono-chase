using _Project.Scripts.Runner.Game.Network;

namespace _Project.Scripts.Runner.Game
{
    public class GameSystem : System
    {
        private NetworkManager _networkManager;

        protected override void SetupManagers()
        {
            _networkManager = GetManager<NetworkManager>();
        }
    }
}
