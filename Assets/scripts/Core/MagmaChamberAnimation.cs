using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MagmaChamberAnimation : MonoBehaviour, IInteractInteraction
    {
        private float _blendShapeValue;
        private int _index;
        private bool _scaleUp = true;

        private SkinnedMeshRenderer _skinnedMeshRenderer;

        public bool Activated;
        public float Speed = 1;

        public void OnToggle()
        {
            Activated = !Activated;
        }

        public void Activate()
        {
            Activated = true;
        }

        public void DeActivate()
        {
            Activated = false;
        }

        public void Reset()
        {
            _index = 0;
            _blendShapeValue = 0;
            _scaleUp = true;
            Activated = false;

            for (var i = 0; i < _skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
            {
                AnimateBlendShapes(i, 0);
            }
        }


        // Use this for initialization
        private void Start()
        {
            _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Activated) return;

            if (_blendShapeValue <= 0 && _index >= GetComponent<SkinnedMeshRenderer>().sharedMesh.blendShapeCount - 1)
            {
                _scaleUp = false;
            }
            else if (_index <= 0)
            {
                _scaleUp = true;
            }

            _blendShapeValue += _scaleUp ? Time.deltaTime*Speed : -Time.deltaTime*(Speed/10);


            if (_scaleUp && _blendShapeValue >= 100)
            {
                _index++;
                _blendShapeValue = 0;
            }

            if (!_scaleUp && _blendShapeValue <= 0)
            {
                _scaleUp = true;
                _index = 0;
                _blendShapeValue = 0;
            }

            AnimateBlendShapes(_index, _blendShapeValue);
            if (_index > 0)
            {
                AnimateBlendShapes(_index - 1, 100 - _blendShapeValue);
            }
        }

        private void AnimateBlendShapes(int blendShapeIndex, float blendShapeValue)
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, blendShapeValue);
        }
    }
}