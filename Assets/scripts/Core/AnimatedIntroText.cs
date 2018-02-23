using UnityEngine;

namespace Assets.Scripts.Core
{
    public class AnimatedIntroText : MonoBehaviour, IHoverInteraction
    {
        private ButtonVisibilityToggler _buttonVisibilityToggler;
        private CanvasGroup _canvasGroup;
        private Vector3 _initialPos;
        private int _initialRotation;
        private Vector3 _targetPosition;
        private float _targetRotation;
        public GameObject CanvasGroup;
        private bool firstStart;
        public float HideOffset;
        public bool HideOffsetSmaller;
        public GameObject PlayButton;
        public GameObject RotationAnchor;
        public float Speed = 2;
        public Vector3 TargetPosition;
        public float XTargetRotation;

        public void OnHoverEnter()
        {
            Activate();
        }

        public void OnHoverExit()
        {
            DeActivate();
        }

        // Use this for initialization
        private void Start()
        {
            _initialPos = RotationAnchor.transform.localPosition;
            _initialRotation = (int) RotationAnchor.transform.localEulerAngles.x;
            _targetPosition = _initialPos;
            _targetRotation = _initialRotation;
            _canvasGroup = CanvasGroup.GetComponent<CanvasGroup>();
            _buttonVisibilityToggler = PlayButton.GetComponent<ButtonVisibilityToggler>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (firstStart && _buttonVisibilityToggler.PlayVisible)
            {
                Activate();
            }
            else
            {
                DeActivate();
            }

            RotationAnchor.transform.localPosition = Vector3.Lerp(RotationAnchor.transform.localPosition,
                _targetPosition, Time.deltaTime*Speed);
            var angle = Mathf.LerpAngle(RotationAnchor.transform.localEulerAngles.x, _targetRotation,
                Time.deltaTime*Speed);
            RotationAnchor.transform.localEulerAngles = new Vector3(angle, 0, 0);

            if (HideOffsetSmaller)
            {
                if (_targetRotation <= HideOffset)
                {
                    _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 0, Time.deltaTime*Speed);
                }
                else
                {
                    _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 1, Time.deltaTime*Speed);
                }
            }
            else
            {
                if (_targetRotation >= HideOffset)
                {
                    _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 0, Time.deltaTime*Speed);
                }
                else
                {
                    _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 1, Time.deltaTime*Speed);
                }
            }
        }

        public void Activate()
        {
            firstStart = true;
            _targetPosition = TargetPosition;
            _targetRotation = XTargetRotation;
        }

        public void DeActivate()
        {
            firstStart = false;
            _targetPosition = _initialPos;
            _targetRotation = _initialRotation;
        }
    }
}