using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ShowCanvasObject : MonoBehaviour, IPlaybackControl
    {
        private CanvasGroup _canvasGroup;
        public GameObject CanvasObject;
        private int lastStateBool;

        public void Pause()
        {
            lastStateBool = 1;
        }

        void IPlaybackControl.Start()
        {
            lastStateBool = 0;
            _canvasGroup.alpha = 1;
        }

        public void ResumeLastState()
        {
            lastStateBool = 0;
            _canvasGroup.alpha = lastStateBool;
        }

        public void Stop()
        {
            lastStateBool = 0;
            _canvasGroup.alpha = 0;
        }

        private void Start()
        {
            lastStateBool = 0;
            _canvasGroup = CanvasObject.GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0;
        }


        // Update is called once per frame
        private void Update()
        {
        }
    }
}