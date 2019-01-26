using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batiment : MonoBehaviour
{
    Camera cam;
    bool readyClick = true;
    //GameObject cube;
    void Start()
    {
        cam = Camera.main;
        //cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);

        //wfs = new WaitForSeconds(0.1f);

        //StartCoroutine(test());
    }

    WaitForSeconds wfs;

    /*IEnumerator test()
    {

        while (true)
        {
            OnMouseUp();
            yield return wfs;
        }
    }*/

    void OnMouseUp ()
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
    }
}