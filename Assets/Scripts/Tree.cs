using UnityEngine;

public class Tree : MonoBehaviour
{
    Camera cam;
    Character Player;

    public LayerMask layerMask;

    void Start()
    {
        Player = GameObject.FindObjectOfType<Character>();
        cam = Camera.main;
    }

    void OnMouseUp()
    {

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f, layerMask))
            return;
        
        CollectWood(hit);
    }

    void CollectWood(RaycastHit hit)
    {
        GameObject wood = hit.collider.gameObject;
        Destroy(wood);
        Player.addResources(ResourceType.Wood, 15);
    }
}
