using UniRx;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ActivateParticleSystems : MonoBehaviour, IPlaybackControl
    {
        private bool lastStateBool;
        public GameObject[] ParticleSystems;

        public void Pause()
        {
            lastStateBool = true;
            ParticleSystems.ToObservable()
                .Select(elem => elem.GetComponent<ParticleSystem>())
                .Where(elem => elem != null)
                .Subscribe(p =>
                {
                    var emission = p.emission;
                    emission.enabled = false;
                });
        }

        void IPlaybackControl.Start()
        {
            lastStateBool = false;
            ParticleSystems.ToObservable()
                .Select(elem => elem.GetComponent<ParticleSystem>())
                .Where(elem => elem != null)
                .Subscribe(p =>
                {
                    p.gameObject.SetActive(true);
                    var emission = p.emission;
                    emission.enabled = true;
                });
        }

        public void ResumeLastState()
        {
            ParticleSystems.ToObservable()
                .Select(elem => elem.GetComponent<ParticleSystem>())
                .Where(elem => elem != null)
                .Subscribe(p =>
                {
                    var emission = p.emission;
                    emission.enabled = lastStateBool;
                });
        }

        public void Stop()
        {
            lastStateBool = false;
            ParticleSystems.ToObservable()
                .Select(elem => elem.GetComponent<ParticleSystem>())
                .Where(elem => elem != null)
                .Subscribe(p =>
                {
                    var emission = p.emission;
                    emission.enabled = false;
                    p.gameObject.SetActive(false);
                });
        }
    }
}