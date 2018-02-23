using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ShowMultipleShapeKeyAnimatedObjects : MonoBehaviour, IPlaybackControl
    {
        private readonly List<AnimateShapeKeys> _animationObjects = new List<AnimateShapeKeys>();
        private float _blendShapeValue = 0;
        private int _index = 0;
        public bool Activated = false;
        private bool lastStateBool;
        public bool Loop;
        public GameObject[] Objects;
        public float Speed = 1;

        public void Pause()
        {
            foreach (var animateShapeKeys in _animationObjects)
            {
                animateShapeKeys.Pause();
            }
        }

        public void ResumeLastState()
        {
            if (!lastStateBool)
            {
                lastStateBool = true;
                return;
            }

            foreach (var animateShapeKeys in _animationObjects)
            {
                animateShapeKeys.ResumeLastState();
            }
        }

        public void Stop()
        {
            foreach (var animateShapeKeys in _animationObjects)
            {
                animateShapeKeys.Stop();
            }
        }

        void IPlaybackControl.Start()
        {
            throw new NotImplementedException();
        }

        // Use this for initialization
        private void Start()
        {
            foreach (var o in Objects)
            {
                _animationObjects.Add(o.GetComponent<AnimateShapeKeys>());
            }
        }
    }
}