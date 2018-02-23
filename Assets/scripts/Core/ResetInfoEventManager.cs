using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ResetInfoEventManager : MonoBehaviour
    {
        public delegate void ResetInfo();

        public static event ResetInfo OnReset;

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void Reset()
        {
            if (OnReset != null) OnReset();
        }
    }
}