using TMPro;
using UnityEngine;

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
        public VoidEventChannelSO NetworkEventChannel;
        
        private void Awake() =>  _canvasGroup = this.GetComponent<CanvasGroup>();

        public void OnFetchWeatherButtonClick()
        {
            string city = cityInputField.text;
            if (!string.IsNullOrEmpty(city))
            {
                weatherData.cityName = city;
                midPanel.SetActive(false);
                descriptionText.text = city;
                
                NetworkEventChannel.RaiseEvent();
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