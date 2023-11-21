using System;
using _Project.Scripts.Runner.Game.Network;
using _Project.Scripts.Runner.Game.UI;
using _Project.Scripts.Runner.Game.Input;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Runner.Game
{
    public class GameSystem : System
    {
        private NetworkManager _networkManager;
        private UIManager _uiManager;
        private InputManager _inputManager;
        private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
        
        public override void Setup()
        {
            base.Setup();
            _networkManager.OnFetchWeatherData += LoadGameScene;
        }

        protected override void SetupManagers()
        {
            _networkManager = GetManager<NetworkManager>();
            _uiManager = GetManager<UIManager>();
            _inputManager = GetManager<InputManager>();
            _uiManager.Setup();
            _networkManager.Setup();

        }

        public void StartTheGame()
        {
            Debug.Log("Entrypoint game started");
        }


        void LoadGameScene()
        {
            SceneManager.sceneLoaded += OnGameSceneLoaded;
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive));
        }

        void OnGameSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (mode == LoadSceneMode.Additive)
            {
                _uiManager.RegisterScreen(FindObjectOfType<GameHUD>());
                _uiManager.ShowScreen<GameHUD>();
            }
        }
    }
}
