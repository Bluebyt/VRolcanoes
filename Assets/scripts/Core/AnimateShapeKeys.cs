using UnityEngine;

namespace Assets.Scripts.Core
{
    public class AnimateShapeKeys : MonoBehaviour, IPlaybackControl
    {
        private float _blendShapeValue;
        private int _index;
        private SkinnedMeshRenderer _skinnedMeshRenderer;
        public bool Activated;
        private bool lastStateBool;
        public bool Loop;
        public float Speed = 1;

        public void Pause()
        {
            lastStateBool = true;
            Activated = false;
            _skinnedMeshRenderer.enabled = true;
        }

        void IPlaybackControl.Start()
        {
            lastStateBool = false;
            Activated = true;
            _skinnedMeshRenderer.enabled = true;
        }

        public void ResumeLastState()
        {
            Activated = lastStateBool;
            _skinnedMeshRenderer.enabled = lastStateBool;
            lastStateBool = false;
        }

        public void Stop()
        {
            lastStateBool = false;
            Activated = false;
            _skinnedMeshRenderer.enabled = false;
        }

        // Use this for initialization
        private void Start()
        {
            _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
            _skinnedMeshRenderer.enabled = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Activated) return;
            if (!Loop && _index >= _skinnedMeshRenderer.sharedMesh.blendShapeCount) return;

            _blendShapeValue += Time.deltaTime*Speed;
            AnimateBlendShapes(_index, _blendShapeValue);

            if (_blendShapeValue > 100)
            {
                _index++;
                _blendShapeValue = 0;
            }
            if (Loop && _index >= _skinnedMeshRenderer.sharedMesh.blendShapeCount)
            {
                _index = 0;
                for (var i = 0; i < _skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
                {
                    AnimateBlendShapes(i, 0);
                }
            }
        }

        private void AnimateBlendShapes(int blendShapeIndex, float blendShapeValue)
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, blendShapeValue);
        }

        public void Reset()
        {
            _index = 0;
            _blendShapeValue = 0;
            Activated = false;

            for (var i = 0; i < _skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
            {
                AnimateBlendShapes(i, 0);
            }
        }

        public void StartIPlayback()
        {
            lastStateBool = false;
            Activated = true;
            _skinnedMeshRenderer.enabled = true;
        }
    }
}