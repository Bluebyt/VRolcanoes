using UnityEngine;

namespace Assets.Scripts.Core
{
    public class AnimatedOverviewCanvas : MonoBehaviour, IVisibilityInteraction
    {
        private CanvasGroup _canvasGroup;
        private Vector3 _initialPos;
        private int _initialRotation;
        private float _targetOpacity;
        private Vector3 _targetPosition;
        private float _targetRotation;
        public GameObject Canvas;
        private bool firstStart;
        public GameObject OverviewPanel;
        public float Speed = 2;
        public Vector3 TargetPosition;
        public float TargetRotation;

        public void Show()
        {
            Activate();
        }

        public void Hide()
        {
            DeActivate();
        }

        // Use this for initialization
        private void Start()
        {
            _initialPos = Canvas.transform.localPosition;
            _initialRotation = (int) Canvas.transform.localEulerAngles.x;
            _targetPosition = _initialPos;
            _targetRotation = _initialRotation;

            _canvasGroup = Canvas.GetComponent<CanvasGroup>();
        }

        // Update is called once per frame
        private void Update()
        {
            Canvas.transform.localPosition = Vector3.Lerp(Canvas.transform.localPosition, _targetPosition,
                Time.deltaTime*Speed);
            var angle = Mathf.LerpAngle(Canvas.transform.localEulerAngles.x, _targetRotation, Time.deltaTime*Speed);
            Canvas.transform.localEulerAngles = new Vector3(angle, 0, 0);

            _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, _targetOpacity, Time.deltaTime*Speed);

            if (_canvasGroup.alpha < 0.1)
            {
                OverviewPanel.SetActive(false);
            }
            else
            {
                OverviewPanel.SetActive(true);
            }
        }

        public void Activate()
        {
            firstStart = true;
            _targetPosition = TargetPosition;
            _targetRotation = TargetRotation;
            _targetOpacity = 1;
        }

        public void DeActivate()
        {
            firstStart = false;
            _targetPosition = _initialPos;
            _targetRotation = _initialRotation;
            _targetOpacity = 0;
        }
    }
}