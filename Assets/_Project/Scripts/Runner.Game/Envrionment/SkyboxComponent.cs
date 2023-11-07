using System;
using UnityEngine;

namespace _Project.Scripts.Runner.Game.Envrionment
{
    public class SkyboxComponent : MonoBehaviour
    {
        [SerializeField] private Material defaultSkybox; // Set this in the Unity Inspector
        [SerializeField] private Material alternateSkybox; // Set this in the Unity Inspector
        private bool _isDefaultSkyboxActive = true;
        
        [SerializeField] private VoidEventChannelSO skyboxEventChannel;
        [SerializeField] private WeatherSO weatherData;

        [SerializeField] private GameObject obj;

        
        private void OnEnable()
        {
            skyboxEventChannel.OnEventRaised += SetSkyboxData;
        }

        private void OnDisable()
        {
            skyboxEventChannel.OnEventRaised -= SetSkyboxData;

        }

        private void SetSkyboxData()
        {
            // Switch the skybox when the button is clicked
            if (_isDefaultSkyboxActive)
            {
                RenderSettings.skybox = alternateSkybox;
            }
            else
            {
                RenderSettings.skybox = defaultSkybox;
            }

            _isDefaultSkyboxActive = !_isDefaultSkyboxActive;
            
            if (weatherData.currentTime > weatherData.sunriseTime && weatherData.currentTime < weatherData.sunsetTime)
            {
                Debug.Log("It is currently morning in the city.");
                obj.transform.rotation = Quaternion.Euler(150, -45, 0);
            }
            else
            {
                Debug.Log("It is currently night in the city.");
                obj.transform.rotation = Quaternion.Euler(-10, -45, 0);
            }
            
        }
        

    }
}