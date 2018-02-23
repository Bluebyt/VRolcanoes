using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MoveToObject : MonoBehaviour, IInteractInteraction
    {
        public void OnToggle()
        {
            SelectObject();
        }

        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void DeActivate()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
        }

        public void SelectObject()
        {
            var targetPosition = transform.position;
            var targetRotation = transform.rotation;
            GameObject.Find("MainPlatform").GetComponent<PlatformMover>().SetNewTarget(targetPosition, targetRotation);
        }
    }
}