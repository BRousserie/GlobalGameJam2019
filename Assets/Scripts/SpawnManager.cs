﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    Camera cam;
    public GameObject batimentPrefab;
    public Character Player;
    public Text Warning;

    public LayerMask layerMask;

    void Start()
    {
        cam = Camera.main;
    }

    WaitForSeconds wfs;

    void OnMouseUp ()
    {
        
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f, layerMask))
            return;
        
        SpawnBuilding(hit);        
    }

    void SpawnBuilding(RaycastHit hit)
    {
        if (Building.selectedBuilding == null) return;

        Resource tmp = Player.canBuy(Building.selectedBuilding.GetComponent<Building>());
        if (tmp != null)
        {
            afficherMessage(tmp);
            return;
        }

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

        Military mil = batiment.GetComponent<Military>();
        if (mil != null) mil.initMilitary();
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