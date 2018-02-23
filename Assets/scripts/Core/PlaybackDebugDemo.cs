using UnityEngine;

namespace Assets.Scripts.Core
{
    public class PlaybackDebugDemo : MonoBehaviour, IPlaybackControl
    {
        public void Pause()
        {
            Debug.Log("Pause");
        }

        void IPlaybackControl.Start()
        {
            Debug.Log("Start");
        }

        public void ResumeLastState()
        {
            Debug.Log("Resume last state");
        }

        public void Stop()
        {
            Debug.Log("Stop");
        }

        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}