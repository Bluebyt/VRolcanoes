using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MenuHandler : MonoBehaviour
    {
        public GameObject Manual;

        public GameObject PlatformOverview;

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void OnShowManual()
        {
            PlatformOverview.SetActive(false);
            Manual.SetActive(true);
        }

        public void OnShowPlatformOverview()
        {
            PlatformOverview.SetActive(true);
            Manual.SetActive(false);
        }
    }
}