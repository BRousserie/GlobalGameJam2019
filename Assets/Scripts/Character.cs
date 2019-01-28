using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Resource[] Resources = Resource.resourcesList();
    public GameObject Mesh;
    public GameObject Orientation;
    private float rotation;
    public StatsUI stats;

    public LayerMask collisionLayer;
    public Transform [] raycastOrigins;
    
    #region get/set/add resources and money
    /**
     * Used to set the whole resources' array 
     */
    public void setResources(Resource[] resources)
    {
        if (resources.Length == Resource.NB_RESOURCE_TYPES)
            Resources = resources;
        else
            throw new System.Exception(
                "Assigning " + resources.Length + " resources " +
                " but " + Resource.NB_RESOURCE_TYPES +
                " different resource types exist (when calling Character.setResources())");
        stats.UpdateInfos();
    }

    /**
     * Used to set one type of resources
     */
    public void setResources(Resource resource)
    {
        Resources[(int)resource.Type].Value = resource.Value;
        stats.UpdateInfos();
    }

    /**
     * Used to set one type of resources without constructing a resource
     */
    public void setResources(ResourceType type, int value)
    {
        Resources[(int)type].Value = value;
        stats.UpdateInfos();
    }

    /**
     * Used when the player recieves or loses resources 
     * resource.Value is negative when losing resources
     */
    public void addResources(ResourceType type, int qte)
    {
        Resources[(int)type].Value += qte;
        stats.UpdateInfos();
    }

    /**
     * Used when the player recieves or loses resources 
     * resource.Value is negative when losing resources
     */
    public void loseResources(Resource[] costs)
    {
        for(int i = 0; i < Resource.NB_RESOURCE_TYPES; i++) 
            Resources[i].Value -= costs[i].Value;
        stats.UpdateInfos();
    }
    #endregion


    public Resource canBuy(Building building)
    {
        for (int i = 0; i < Resource.NB_RESOURCE_TYPES; i++)
            if (Resources[i].Value < building.Costs[i].Value) return building.Costs[i];
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 globalRotation = Vector3.zero;
        
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            globalRotation.y = 15f;
            globalRotation.z = 15f;
            rotation = -45;
        }

        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            globalRotation.y = -15f;
            globalRotation.z = 15f;
            rotation = 45;
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            globalRotation.y = 15f;
            globalRotation.z = -15f;
            rotation = -135;
        }


        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            globalRotation.y = -15f;
            globalRotation.z = -15f;
            rotation = 135;
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            globalRotation.y = 15f;
            rotation = -90;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            globalRotation.y = -15f;
            rotation = 90;
        }
        
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            globalRotation.z = 15f;
            rotation = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            globalRotation.z = -15f;
            rotation = 180;
        }
        Mesh.transform.localRotation = Quaternion.Euler(rotation, 0, 0);

        if (!FoundObstacle())
        {
            // Ajout de Time deltaTime pour que ça soit une rotation par seconde...
            transform.Rotate(globalRotation * Time.deltaTime);
        }
        //Mesh.transform.LookAt(Orientation.transform, Mesh.transform.up);
    }

    bool FoundObstacle ()
    {
        for (int i = 0; i < raycastOrigins.Length; i++)
        {
            Vector3 fwd = raycastOrigins[i].transform.TransformDirection(Vector3.up);
            Debug.DrawRay(raycastOrigins[i].transform.position, fwd * 0.02f, Color.green);

            if (Physics.Raycast(raycastOrigins[i].transform.position, fwd, 0.02f, collisionLayer))
            {
                return true;
            }
        }

        return false;
    }

}
