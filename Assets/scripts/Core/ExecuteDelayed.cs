using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public static class ExecuteDelayed
    {
        public static GameObject StartCoroutine(this GameObject gameObject, IEnumerator coroutine)
        {
            var behaviour = gameObject.GetComponent<CoroutineHelper>();
            if (!behaviour)
                behaviour = gameObject.AddComponent<CoroutineHelper>();
            behaviour.StartCoroutine(coroutine);
            return behaviour.gameObject;
        }

        private static IEnumerator WaitForAPeriodOfTime(float timeToWait, Action thingToDo, WaitController controller)
        {
            while (timeToWait > 0)
            {
                if (!controller.Pause)
                    timeToWait -= Time.deltaTime;
                if (controller.Cancel)
                    yield break;
                yield return null;
            }
            thingToDo();
        }

        public static WaitController DoSomethingLater(this GameObject gameObject, Action thingToDo, float timeToWait)
        {
            var controller = new WaitController();
            controller.obj = gameObject.StartCoroutine(WaitForAPeriodOfTime(timeToWait, thingToDo, controller));
            return controller;
        }

        public class CoroutineHelper : MonoBehaviour
        {
        }

        public class WaitController
        {
            public bool Cancel;
            public GameObject obj;
            public bool Pause;
        }
    }
}