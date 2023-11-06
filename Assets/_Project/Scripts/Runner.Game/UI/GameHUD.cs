using _Project.Scripts.Runner.Game.Envrionment;
using _Project.Scripts.Runner.Game.Network;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Project.Scripts.Runner.Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameHUD : MonoBehaviour, IUIScreen
    {
        private CanvasGroup _canvasGroup;
        
        [SerializeField] private TMP_InputField cityInputField;
        
        private void Awake()
        {
            _canvasGroup = this.GetComponent<CanvasGroup>();
        }
        
        public void OnFetchWeatherButtonClick()
        {
            string city = cityInputField.text;
            if (!string.IsNullOrEmpty(city))
            {
                
            }
            else
            {
                Debug.LogWarning("Please enter a city name.");
            }
        }

        public void Show()
        {
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
        }
    }
}