using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MoveObjectInUpDirection : MonoBehaviour, IPlaybackControl
    {
        private bool _lastStateBool;

        private bool _shouldMove;

        public void Pause()
        {
            _lastStateBool = true;
            _shouldMove = false;
        }

        public void ResumeLastState()
        {
            _shouldMove = _lastStateBool;
        }

        public void Stop()
        {
            _shouldMove = false;
            _lastStateBool = false;
        }

        void IPlaybackControl.Start()
        {
            _shouldMove = true;
            _lastStateBool = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_shouldMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up,
                    Time.deltaTime*1);
            }
        }
    }
}