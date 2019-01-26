using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    Camera cam;
    bool readyClick = true;
    public GameObject batimentPrefab;
    public Character Player;
    public Text Warning;

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
        if (Building.selectedBuilding == null) return;

        Resource tmp = Player.canBuy(Building.selectedBuilding.GetComponent<Building>());
        if (tmp != null) {
            afficherMessage(tmp);
            return;
        }
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

        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
        
        GameObject batiment = Instantiate(Building.selectedBuilding, p0, rotation);
        Player.loseResources(Building.selectedBuilding.GetComponent<Building>().Costs);

        Commercial com = batiment.GetComponent<Commercial>();
        if (com != null) com.Player = Player;
    }
    
    void afficherMessage(Resource res)
    {
        Warning.transform.parent.gameObject.SetActive(true);
        Warning.text = "You need " + res.Value + " " + res.Type;
        StartCoroutine(delayHide());
    }

    IEnumerator delayHide()
    {
        yield return new WaitForSeconds(3f);
        Warning.transform.parent.gameObject.SetActive(false);
    }
}