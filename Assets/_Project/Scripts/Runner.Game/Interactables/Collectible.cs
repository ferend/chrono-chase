using _Project.Scripts.Runner.Game.Player;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Scripts.Runner.Game.Interactables
{
    public class CollectibleComponent : Interactable
    {
        private MeshRenderer _meshRenderer;
        private WaitForSeconds wait = new WaitForSeconds(1f);

        private void Start()
        {
            _meshRenderer = this.GetComponent<MeshRenderer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerComponent ctrl))
            {
                OnInteraction();
            }
        }


        public override void OnInteraction()
        {
            _meshRenderer.enabled = false;
            StartCoroutine(ActivateObject());
        }
        

        private IEnumerator ActivateObject()
        {
            yield return wait;
            _meshRenderer.enabled = true;
        }
    }
}