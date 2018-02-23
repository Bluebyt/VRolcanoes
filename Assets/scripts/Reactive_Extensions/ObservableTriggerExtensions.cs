using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Reactive_Extensions
{
    public static class ObservableTriggerExtensions
    {
        public static IObservable<PointerEventData> OnPointerEnterAsObservable(this Component component)
        {
            if (component == null || component.gameObject == null) return Observable.Empty<PointerEventData>();
            return GetOrAddComponent<ObservablePointerEnterTrigger>(component.gameObject).OnPointerEnterAsObservable();
        }

        public static IObservable<PointerEventData> OnPointerExitAsObservable(this Component component)
        {
            if (component == null || component.gameObject == null) return Observable.Empty<PointerEventData>();
            return GetOrAddComponent<ObservablePointerExitTrigger>(component.gameObject).OnPointerExitAsObservable();
        }

        public static IObservable<PointerEventData> OnPointerClickAsObservable(this Component component)
        {
            if (component == null || component.gameObject == null) return Observable.Empty<PointerEventData>();
            return GetOrAddComponent<ObservablePointerClickTrigger>(component.gameObject).OnPointerClickAsObservable();
        }

        public static IObservable<Unit> OnCardboardTriggerDownAsObservable(this Component component)
        {
            if (component == null || component.gameObject == null) return Observable.Empty<Unit>();
            return
                GetOrAddComponent<ObservableCardboardTriggerTrigger>(component.gameObject)
                    .OnCardboardTriggerDownAsObservable();
        }

        public static T GetOrAddComponent<T>(GameObject gObj) where T : Component
        {
            if (gObj.GetComponent<T>() != null)
            {
                return gObj.GetComponent<T>();
            }
            return gObj.AddComponent<T>();
        }
    }
}