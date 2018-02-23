using UnityEngine;

namespace Assets.Scripts.Core
{
    public class AnimationStateHandler : MonoBehaviour, IPlaybackControl
    {
        private Animation _animation;
        private bool _lastStateBool;
        public string AnimationName = "Default Take";

        public void Pause()
        {
            _lastStateBool = true;
            _animation[AnimationName].enabled = false;
        }

        void IPlaybackControl.Start()
        {
            _lastStateBool = true;
            _animation[AnimationName].enabled = true;
        }

        public void ResumeLastState()
        {
            _animation[AnimationName].enabled = _lastStateBool;
        }

        public void Stop()
        {
            _lastStateBool = false;
            var anim = _animation[AnimationName];
            anim.time = 0;
            anim.enabled = true;
            _animation.Sample();
            anim.enabled = false;
        }

        private void Start()
        {
            _animation = GetComponent<Animation>();
            _animation.Play();
            _animation[AnimationName].time = 0;
            _animation[AnimationName].enabled = true;
            _animation.Sample();
            _animation[AnimationName].enabled = false;
        }
    }
}