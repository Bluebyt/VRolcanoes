using UnityEngine;

namespace Assets.Scripts.Core
{
    public class AnimationPlaybackTest : MonoBehaviour, IPlaybackControl
    {
        private Vector3 _initialPos;
        private bool lastStateBool;

        private bool move;
        private readonly float speed = 2f;

        public void Pause()
        {
            lastStateBool = move;
            move = false;
        }

        void IPlaybackControl.Start()
        {
            lastStateBool = move;
            move = true;
        }

        public void ResumeLastState()
        {
            move = lastStateBool;
        }

        public void Stop()
        {
            lastStateBool = false;
            move = false;
            transform.position = _initialPos;
        }

        private void Start()
        {
            _initialPos = transform.position;
        }

        // Update is called once per frame
        private void Update()
        {
            if (move)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up,
                    speed*Time.deltaTime);
            }
        }
    }
}