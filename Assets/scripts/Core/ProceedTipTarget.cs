using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ProceedTipTarget : MonoBehaviour
    {
        private PlatformMover _mover;
        public GameObject Target;

        // Use this for initialization
        private void Start()
        {
            _mover = GameObject.Find("MainPlatform").GetComponent<PlatformMover>();
        }

        public void OnProceedClick()
        {
            _mover.SetNewTarget(Target.transform.position, Target.transform.rotation);
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}