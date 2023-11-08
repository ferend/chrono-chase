using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runner.Game.UI
{
    public class UIManager : Manager
    {
        private Dictionary<Type, IUIScreen> _screenDictionary = new Dictionary<Type, IUIScreen>();

        public void ShowScreen<T>() where T : IUIScreen
        {
            if (_screenDictionary.ContainsKey(typeof(T)))
            {
                _screenDictionary[typeof(T)].Show();
            }
        }

        public void HideScreen<T>() where T : IUIScreen
        {
            if (_screenDictionary.ContainsKey(typeof(T)))
            {
                _screenDictionary[typeof(T)].Hide();
            }
        }

        public void RegisterScreen<T>(T screen) where T : IUIScreen
        {
            if (!_screenDictionary.ContainsKey(typeof(T)))
            {
                _screenDictionary.Add(typeof(T), screen);
            }
        }

    }
}