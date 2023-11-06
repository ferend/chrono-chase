using System;
using UnityEngine;

namespace _Project.Scripts.Runner.Game.Envrionment
{
    public class SkyboxComponent : MonoBehaviour
    {
        [SerializeField] private Material defaultSkybox; // Set this in the Unity Inspector
        [SerializeField] private Material alternateSkybox; // Set this in the Unity Inspector
        private bool _isDefaultSkyboxActive = true;
        public VoidEventChannelSO skyboxEventChannel;

        private void Start()
        {
            skyboxEventChannel.OnEventRaised += SetSkyboxData;
        }

        public void SetSkyboxData()
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
        }

    }
}