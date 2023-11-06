using TMPro;
using UnityEngine;


namespace _Project.Scripts.Runner.Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameHUD : MonoBehaviour, IUIScreen
    {
        private CanvasGroup _canvasGroup;
        
        [SerializeField] private TMP_InputField cityInputField;
        [SerializeField] private GameObject midPanel;
        [SerializeField] private TextMeshProUGUI descriptionText;
        
        public WeatherSO weatherData;
       
        private void Awake() => _canvasGroup = this.GetComponent<CanvasGroup>();

        public void OnFetchWeatherButtonClick()
        {
            string city = cityInputField.text;
            if (!string.IsNullOrEmpty(city))
            {
                weatherData.cityName = city;
                midPanel.SetActive(false);
                descriptionText.text = city;
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