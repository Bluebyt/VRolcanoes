using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ResetPlaybackController : MonoBehaviour, IPlaybackControl
    {
        private PlaybackController _playbackController;


        public GameObject PlaybackController;

        public void Pause()
        {
        }

        void IPlaybackControl.Start()
        {
            _playbackController.Reset();
        }

        public void ResumeLastState()
        {
        }

        public void Stop()
        {
        }

        private void Start()
        {
            _playbackController = PlaybackController.GetComponent<PlaybackController>();
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}