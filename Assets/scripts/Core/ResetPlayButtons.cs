using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ResetPlayButtons : MonoBehaviour, IPlaybackControl
    {
        private ButtonVisibilityToggler _buttonVisibilityToggler;

        public GameObject PlayButton;

        public void Pause()
        {
        }

        void IPlaybackControl.Start()
        {
            _buttonVisibilityToggler.Reset();
        }

        public void ResumeLastState()
        {
        }

        public void Stop()
        {
            _buttonVisibilityToggler.Reset();
        }

        private void Start()
        {
            _buttonVisibilityToggler = PlayButton.GetComponent<ButtonVisibilityToggler>();
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}