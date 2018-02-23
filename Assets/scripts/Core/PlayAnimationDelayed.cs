using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class PlayAnimationDelayed : MonoBehaviour
    {
        private Animation _animation;
        private float _delay;
        public float Delay = 0;
        public float MaxRandom = 1;

        private void Awake()
        {
            _delay = Delay + Random.Range(0, MaxRandom);
            StartCoroutine(PlayDelayed());
            _animation = GetComponent<Animation>();
            _animation.playAutomatically = false;
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private IEnumerator PlayDelayed()
        {
            yield return new WaitForSeconds(_delay);
            _animation.Play();
        }
    }
}