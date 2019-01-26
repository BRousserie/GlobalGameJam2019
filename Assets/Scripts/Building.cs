using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public static GameObject selectedBuilding;

    public Resource[] Costs = Resource.resourcesList(); // building costs by resource type

    /*void OnMouseUp()
    {
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;

        MeshCollider meshCollider = hit.collider as MeshCollider;
        if (meshCollider == null || meshCollider.sharedMesh == null)
            return;

        Mesh mesh = meshCollider.sharedMesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int[] triangles = mesh.triangles;
        Vector3 p0 = vertices[triangles[hit.triangleIndex * 3]];
        Vector3 normal = normals[triangles[hit.triangleIndex * 3]];
        Transform hitTransform = hit.collider.transform;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = p0;
        cube.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
        cube.transform.rotation = Quaternion.FromToRotation(transform.up, normal) * transform.rotation;
    }*/
}
