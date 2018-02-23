using UnityEngine;

namespace Assets.Scripts.Common
{
    public static class GameobjectExtensions
    {
        public static Bounds CalculateBoundsWithChildren(this GameObject obj, string includeTag = "",
            string excludeTag = "")
        {
            var currentRotation = obj.transform.rotation;
            obj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            var bounds = new Bounds(obj.transform.position, Vector3.zero);

            foreach (var renderer in obj.GetComponentsInChildren<Renderer>())
            {
                if (excludeTag == "" && renderer.gameObject.tag != excludeTag)
                {
                    if (includeTag == "" || renderer.gameObject.tag == includeTag)
                    {
                        bounds.Encapsulate(renderer.bounds);
                    }
                }
            }

            var localCenter = bounds.center - obj.transform.position;
            bounds.center = localCenter;

            obj.transform.rotation = currentRotation;

            return bounds;
        }


        public static Bounds CalculateGlobalBoundsOfChildren(this GameObject obj, string includeTag = "",
            string excludeTag = "")
        {
            var currentRotation = obj.transform.rotation;
            obj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            var bounds = new Bounds();
            var boundSet = false;

            foreach (var renderer in obj.GetComponentsInChildren<Renderer>())
            {
                if (!boundSet)
                {
                    bounds = new Bounds(renderer.transform.position, Vector3.zero);
                    boundSet = true;
                }
                if (excludeTag == "" || renderer.gameObject.tag != excludeTag)
                {
                    if (includeTag == "" || renderer.gameObject.tag == includeTag)
                    {
                        bounds.Encapsulate(renderer.bounds);
                    }
                }
            }

            obj.transform.rotation = currentRotation;

            return bounds;
        }

        public static void ChangeGameObjectLayerRecursive(this GameObject obj, string name)
        {
            ChangeGameObjectLayerRecursive(obj, LayerMask.NameToLayer(name));
        }

        public static void ChangeGameObjectLayerRecursive(this GameObject obj, int layer)
        {
            obj.layer = layer;
            foreach (Transform child in obj.transform)
            {
                ChangeGameObjectLayerRecursive(child.gameObject, layer);
            }
        }
    }
}