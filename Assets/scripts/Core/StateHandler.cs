using Assets.Scripts.Reactive_Extensions;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class StateHandler : MonoBehaviour
    {
        private float _distance;
        private GameObject _mainPlatform;
        private bool _selected;
        public float ClickDelay;
        public bool DeactivateEffectsOnPositionChange = true;
        public bool DelayClickState;
        public bool DelayHoverEffect;
        public bool DisableHoverOnClick = false;
        public float Distance = 4;
        public GameObject DistanceOriginGameObject;
        public GameObject DistanceTargetGameObject;
        public float DistanceThrottle = 250;
        public float HoverDelay;
        public float HoverMinDistance = 3f;
        public GameObject[] Objects;
        public bool UseClick = true;
        public bool UseDistance = true;
        public bool UseHover = true;
        public bool UseHoverMinDistance = true;

        private void OnEnable()
        {
            if (DeactivateEffectsOnPositionChange)
            {
                ResetInfoEventManager.OnReset += ResetAll;
            }
        }

        private void OnDisable()
        {
            if (DeactivateEffectsOnPositionChange)
            {
                ResetInfoEventManager.OnReset -= ResetAll;
            }
        }

        private void Awake()
        {
            gameObject.AddComponent<ObservablePointerEnterTrigger>();
            gameObject.AddComponent<ObservablePointerExitTrigger>();
            gameObject.AddComponent<ObservablePointerClickTrigger>();
            gameObject.AddComponent<ObservableUpdateTrigger>();
        }

        private void Start()
        {
            _mainPlatform = GameObject.Find("MainPlatform").gameObject;

            if (UseHover)
            {
                this.OnPointerEnterAsObservable()
                    .Subscribe(elem => OnHoverEnter());

                this.OnPointerExitAsObservable()
                    .Subscribe(elem => OnHoverExit());
            }

            if (UseClick)
            {
                this.OnPointerClickAsObservable()
                    .Subscribe(elem => OnClick());
            }

            if (UseHoverMinDistance)
            {
                this.UpdateAsObservable()
                    .Subscribe(_ =>
                    {
                        _distance = Vector3.Distance(transform.position, _mainPlatform.transform.position);
                        if (_distance < HoverMinDistance)
                        {
                            OnHoverExit();
                        }
                    });
            }

            if (UseDistance)
            {
                this.UpdateAsObservable()
                    .Subscribe(_ =>
                    {
                        OnDistanceChange();

                        if (_selected)
                        {
                            OnHoverExit();
                        }
                    });
            }
        }

        public void ResetAll()
        {
            _selected = false;

            Objects.ToObservable()
                .SelectMany(obj => obj.GetComponents<IInteractInteraction>())
                .Where(selectable => selectable != null)
                .Do(selectable => selectable.Reset())
                .Subscribe();
        }

        public void OnHoverEnter()
        {
            Objects.ToObservable()
                .SelectMany(obj => obj.GetComponents<IHoverInteraction>())
                .Where(selectable => selectable != null)
                .Do(selectable => selectable.OnHoverEnter())
                .Subscribe();
        }

        public void OnHoverExit()
        {
            Objects.ToObservable()
                .SelectMany(obj => obj.GetComponents<IHoverInteraction>())
                .Where(selectable => selectable != null)
                .Do(selectable => selectable.OnHoverExit())
                .Subscribe();
        }

        public void OnClick()
        {
            Objects.ToObservable()
                .SelectMany(obj => obj.GetComponents<IInteractInteraction>())
                .Where(selectable => selectable != null)
                .Do(elem => elem.OnToggle())
                .Subscribe();

            _selected = DisableHoverOnClick && true;
        }

        public void OnDistanceChange()
        {
            Objects.ToObservable()
                .Where(obj => obj.GetComponent<IVisibilityInteraction>() != null)
                .Do(elem =>
                {
                    var target = DistanceTargetGameObject
                        ? DistanceTargetGameObject.transform.position
                        : Camera.main.transform.position;
                    var origin = DistanceOriginGameObject
                        ? DistanceOriginGameObject.transform.position
                        : transform.position;

                    if (Vector3.Distance(origin, target) < Distance)
                    {
                        elem.GetComponent<IVisibilityInteraction>().Show();
                    }
                    else
                    {
                        elem.GetComponent<IVisibilityInteraction>().Hide();
                    }
                })
                .Subscribe();
        }
    }
}