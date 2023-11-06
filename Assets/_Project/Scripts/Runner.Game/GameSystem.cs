using System;
using _Project.Scripts.Runner.Game.Network;
using _Project.Scripts.Runner.Game.UI;

namespace _Project.Scripts.Runner.Game
{
    public class GameSystem : System
    {
        private NetworkManager _networkManager;
        private UIManager _uiManager;
        

        protected override void SetupManagers()
        {
            _networkManager = GetManager<NetworkManager>();
            _uiManager = GetManager<UIManager>();
            _uiManager.Setup();

            _uiManager.ShowScreen<GameHUD>();

        }
        
    }
}
