using UnityEngine;

namespace Assets.Scripts.Core
{
    public class InteractionEffectDemo : MonoBehaviour, IInteractInteraction
    {
        private bool active;

        public void OnToggle()
        {
            active = !active;
            if (active)
            {
                Activate();
            }
            else
            {
                DeActivate();
            }
        }

        public void Activate()
        {
            Debug.Log("Action triggered (Activate), put your custom code here");
        }

        public void DeActivate()
        {
            Debug.Log("Action triggered (Deactivate), put your custom code here");
        }

        public void Reset()
        {
            Debug.Log("Reset object state here");
        }

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}