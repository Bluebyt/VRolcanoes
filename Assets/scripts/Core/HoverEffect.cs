using UnityEngine;

namespace Assets.Scripts.Core
{
    public class HoverEffect : MonoBehaviour, IHoverInteraction
    {
        private Vector3 _initialScale;
        private Vector3 _targetScale;
        public float ScaleFactor = 2;
        public float ScaleSpeed = 3;

        public void OnHoverEnter()
        {
            _targetScale = _initialScale*2;
        }

        public void OnHoverExit()
        {
            _targetScale = _initialScale;
        }

        // Use this for initialization
        private void Start()
        {
            _initialScale = transform.localScale;
            _targetScale = transform.localScale;
        }

        // Update is called once per frame
        private void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, Time.deltaTime*ScaleSpeed);
        }
    }
}