using UnityEngine;

namespace Assets.Scripts.Core
{
    public class AudioStateHandler : MonoBehaviour, IPlaybackControl
    {
        private AudioSource _audioSource;
        private bool lastStateBool;

        public void Pause()
        {
            lastStateBool = true;
            _audioSource.Pause();
        }

        void IPlaybackControl.Start()
        {
            lastStateBool = false;
            _audioSource.UnPause();
        }

        public void ResumeLastState()
        {
            if (lastStateBool)
            {
                _audioSource.UnPause();
            }
        }

        public void Stop()
        {
            lastStateBool = false;
            _audioSource.Stop();
            _audioSource.Play();
            _audioSource.Pause();
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            _audioSource.Pause();
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}