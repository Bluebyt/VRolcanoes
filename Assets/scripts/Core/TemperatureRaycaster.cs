using UnityEngine;

namespace Assets.Scripts.Core
{
    public class TemperatureRaycaster : MonoBehaviour
    {
        // Update is called once per frame
        private void Update()
        {
            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var meshCollider = hit.collider as MeshCollider;

                if (meshCollider != null)
                {
                    var mesh = meshCollider.sharedMesh;

                    // There are 3 indices stored per triangle
                    var limit = hit.triangleIndex*3;
                    int submesh;
                    for (submesh = 0; submesh < mesh.subMeshCount; submesh++)
                    {
                        var numIndices = mesh.GetTriangles(submesh).Length;
                        if (numIndices > limit)
                            break;

                        limit -= numIndices;
                    }

                    var material = meshCollider.GetComponent<MeshRenderer>().sharedMaterials[submesh];
                }
                else
                {
                    var material = hit.transform.gameObject.GetComponent<Material>();
                }
            }
        }
    }
}