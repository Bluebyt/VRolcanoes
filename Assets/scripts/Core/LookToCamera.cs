using UnityEngine;

namespace Assets.Scripts.Core
{
    public class LookToCamera : MonoBehaviour
    {
        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            transform.LookAt(Camera.main.transform.position);
        }
    }
}