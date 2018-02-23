using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ChangeMaterial : MonoBehaviour, IPlaybackControl
    {
        private Material _initial;
        private Renderer _renderer;

        public Material TargetMaterial;

        public void Pause()
        {
        }

        void IPlaybackControl.Start()
        {
            _renderer.material = TargetMaterial;
        }

        public void ResumeLastState()
        {
        }

        public void Stop()
        {
            _renderer.material = _initial;
        }

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _initial = _renderer.material;
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}