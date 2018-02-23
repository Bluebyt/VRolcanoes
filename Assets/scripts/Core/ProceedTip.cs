using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core
{
    public class ProceedTip : MonoBehaviour, IPlaybackControl
    {
        private Scrollbar _scrollbar;
        private float _value = 1;
        public GameObject Panel;
        public float Speed = 2f;

        public void Pause()
        {
            _value = _scrollbar.value;
        }

        void IPlaybackControl.Start()
        {
            _value = 0;
        }

        public void ResumeLastState()
        {
            _value = 1;
        }

        public void Stop()
        {
        }

        public void ResetTip()
        {
            _value = 1;
        }

        private void OnEnable()
        {
            ResetInfoEventManager.OnReset += ResetTip;
        }

        private void OnDisable()
        {
            ResetInfoEventManager.OnReset -= ResetTip;
        }

        private void Start()
        {
            _scrollbar = Panel.GetComponent<Scrollbar>();
        }

        // Update is called once per frame
        private void Update()
        {
            _scrollbar.value = Mathf.Lerp(_scrollbar.value, _value, Time.deltaTime*Speed);
        }
    }
}