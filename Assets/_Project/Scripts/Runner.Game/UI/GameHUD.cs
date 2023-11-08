using System;
using TMPro;
using UnityEngine;


namespace _Project.Scripts.Runner.Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameHUD : MonoBehaviour, IUIScreen
    {
        [SerializeField] private CanvasGroup canvasGroup;
        
        [SerializeField] private TextMeshProUGUI upperText;
        [SerializeField] private WeatherSO weatherSo;

        private void Start() => upperText.text = weatherSo.cityName;

        public void Show()
        {
            canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            canvasGroup.alpha = 0;
        }
    }
}