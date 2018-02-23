namespace Assets.Scripts.Core
{
    public interface IPlaybackControl
    {
        void Pause();
        void Start();
        void ResumeLastState();
        void Stop();
    }
}