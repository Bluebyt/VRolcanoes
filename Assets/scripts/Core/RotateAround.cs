using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public enum RotationAxis
    {
        Y,
        X,
        Z
    }

    public class RotateAround : MonoBehaviour, IInteractInteraction, IPlaybackControl
    {
        private bool _rotate;
        public bool AutoRotateOnStart = false;
        public RotationAxis RotationAxis = RotationAxis.Y;
        public float Speed = 1;

        public void OnToggle()
        {
            _rotate = !_rotate;
        }

        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void DeActivate()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
        }

        void IPlaybackControl.Start()
        {
        }

        public void ResumeLastState()
        {
        }

        public void Stop()
        {
            _rotate = false;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            if (!AutoRotateOnStart && !_rotate) return;

            var axis = new Vector3(
                RotationAxis == RotationAxis.X ? 1 : 0,
                RotationAxis == RotationAxis.Y ? 1 : 0,
                RotationAxis == RotationAxis.Z ? 1 : 0);

            transform.Rotate(axis, Speed*Time.deltaTime);
        }
    }
}