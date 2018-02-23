using UnityEngine;

namespace Assets.Scripts.Core
{
    public class FadeOutIn : MonoBehaviour
    {
        private Material _material;
        private GameObject _target;
        private float _targetOpacity = 1f;
        public float Distance = 3f;
        public float maxOpacity = 0.5f;
        public float minOpacity = 0.0f;
        public float Speed = 2f;

        public GameObject Target;

        // Use this for initialization
        private void Start()
        {
            if (Target == null)
            {
                _target = Camera.main.gameObject;
            }
            _material = GetComponent<Renderer>().material;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Vector3.Distance(_target.transform.position, transform.position) > Distance)
            {
                _targetOpacity = maxOpacity;
            }
            else
            {
                _targetOpacity = minOpacity;
            }
            var color = _material.color;
            color.a = Mathf.Lerp(_material.color.a, _targetOpacity, Time.deltaTime*Speed);
            _material.color = color;
        }
    }
}