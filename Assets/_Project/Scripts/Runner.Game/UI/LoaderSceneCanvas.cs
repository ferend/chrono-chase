using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Runner.Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]

    public class LoaderSceneCanvas: MonoBehaviour, IUIScreen
    {
        private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_InputField cityInputField;
        [SerializeField] private GameObject midPanel;
        [SerializeField] private TextMeshProUGUI descriptionText;
        
        public WeatherSO weatherData;
        public EventChannel EventChannel;
        
        private void Awake() =>  _canvasGroup = this.GetComponent<CanvasGroup>();

        public void OnFetchWeatherButtonClick()
        {
            string city = cityInputField.text;
            if (!string.IsNullOrEmpty(city))
            {
                weatherData.cityName = city;
                midPanel.SetActive(false);
                descriptionText.text = city;
                
                EventChannel.Raise();
            }
            else
            {
                descriptionText.text = "Please enter a city name.";
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