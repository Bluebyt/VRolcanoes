namespace Assets.Scripts.Core
{
    public interface IHoverInteraction
    {
        void OnHoverEnter();
        void OnHoverExit();
    }

    public interface IInteractInteraction
    {
        void OnToggle();
        void Activate();
        void DeActivate();
        void Reset();
    }

    public interface IVisibilityInteraction
    {
        void Show();
        void Hide();
    }
}