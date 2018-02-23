using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ShowHintObject : MonoBehaviour, IPlaybackControl
    {
        private MeshRenderer _meshRenderer;

        public GameObject HintObject;
        private bool lastStateBool;

        public void Pause()
        {
            lastStateBool = true;
        }

        void IPlaybackControl.Start()
        {
            lastStateBool = false;
            _meshRenderer.enabled = true;
        }

        public void ResumeLastState()
        {
            lastStateBool = false;
            _meshRenderer.enabled = lastStateBool;
        }

        public void Stop()
        {
            lastStateBool = false;
            _meshRenderer.enabled = false;
        }

        private void Start()
        {
            lastStateBool = false;
            _meshRenderer = HintObject.GetComponent<MeshRenderer>();
            _meshRenderer.enabled = false;
        }


        // Update is called once per frame
        private void Update()
        {
        }
    }
}