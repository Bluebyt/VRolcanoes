using System;
using Assets.Scripts.Reactive_Extensions;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class PlatformMover : MonoBehaviour
    {
        private Vector3 _backupPosition;
        private bool _showOverview;
        private Vector3 _targetPosition;
        private Quaternion _targetRotation;
        public float LerpSpeed = 1;
        public GameObject OverviewTarget;

        private void Awake()
        {
            gameObject.AddComponent<ObservableCardboardTriggerTrigger>();
        }

        // Use this for initialization
        private void Start()
        {
            _targetPosition = transform.position;
            _targetRotation = transform.rotation;

            var clickStream = this.OnCardboardTriggerDownAsObservable();
            clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
                .Where(cptf => cptf.Count >= 2)
                .Subscribe(_ => ShowOverview());
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_showOverview)
            {
                transform.position = Vector3.Lerp(transform.position, _targetPosition,
                    Time.deltaTime*LerpSpeed);
                transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime*LerpSpeed);
            }
            else if (_showOverview)
            {
                transform.position = Vector3.Lerp(transform.position, OverviewTarget.transform.position,
                    Time.deltaTime*LerpSpeed);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 90, 0),
                    Time.deltaTime*LerpSpeed);
            }
        }

        public void SetNewTarget(Vector3 position, Quaternion rotation)
        {
            _showOverview = false;
            _targetPosition = position;
            _targetRotation = rotation;
            GameObject.Find("EventSystem").GetComponent<ResetInfoEventManager>().Reset();
        }

        private float HypotenuseLength(float sideALength, float sideBLength)
        {
            return Mathf.Sqrt(sideALength*sideALength + sideBLength*sideBLength);
        }

        public void ShowOverview()
        {
            GameObject.Find("EventSystem").GetComponent<ResetInfoEventManager>().Reset();
            _showOverview = !_showOverview;
        }
    }
}