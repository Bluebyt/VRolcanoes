using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Reactive_Extensions
{
    public class ObservableCardboardTriggerTrigger : ObservableTriggerBase
    {
        private Subject<Unit> onCardboardTriggerDown;

        private void Update()
        {
            if (GvrViewer.Instance.Triggered)
            {
                if (onCardboardTriggerDown != null) onCardboardTriggerDown.OnNext(Unit.Default);
            }
        }

        public IObservable<Unit> OnCardboardTriggerDownAsObservable()
        {
            return onCardboardTriggerDown ?? (onCardboardTriggerDown = new Subject<Unit>());
        }

        protected override void RaiseOnCompletedOnDestroy()
        {
            if (onCardboardTriggerDown != null)
            {
                onCardboardTriggerDown.OnCompleted();
            }
        }
    }
}