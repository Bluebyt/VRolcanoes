using UnityEngine;

namespace Assets.Scripts.Core
{
    public class CameraMover : MonoBehaviour
    {
        public GameObject PlatformCameraPosition;

        // Update is called once per frame
        private void Update()
        {
            transform.position = PlatformCameraPosition.transform.position;
        }
    }
}