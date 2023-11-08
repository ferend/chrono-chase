using System;
using _Project.Scripts.Runner.Game.Network;
using _Project.Scripts.Runner.Game.UI;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Runner.Game
{
    public class GameSystem : System
    {
        private NetworkManager _networkManager;
        private UIManager _uiManager;
        
        public override void Setup()
        {
            base.Setup();
            _networkManager.OnFetchWeatherData += LoadGameScene;
        }

        protected override void SetupManagers()
        {
            _networkManager = GetManager<NetworkManager>();
            _uiManager = GetManager<UIManager>();
            _uiManager.Setup();
            _networkManager.Setup();

        }

   
        void LoadGameScene()
        {
            SceneManager.sceneLoaded += OnGameSceneLoaded;
            SceneManager.LoadScene("Game");
        }

        void OnGameSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (mode == LoadSceneMode.Single)
            {
                _uiManager.RegisterScreen(FindObjectOfType<GameHUD>());
                _uiManager.ShowScreen<GameHUD>();
            }
        }
    }
}
