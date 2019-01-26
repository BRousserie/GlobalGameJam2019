using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Resource[] Resources = new Resource[Resource.NB_RESOURCE_TYPES];
    public int Money;
    public GameObject Mesh;
    public GameObject Orientation;
    private float rotation;
    
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
    }

    /**
     * Used to set one type of resources
     */
    public void setResources(Resource resource)
    {
        Resources[(int)resource.Type].Value = resource.Value;
    }

    /**
     * Used to set one type of resources without constructing a resource
     */
    public void setResources(ResourceType type, int value)
    {
        Resources[(int)type].Value = value;
    }

    /**
     * Used when the player recieves or loses resources 
     * resource.Value is negative when losing resources
     */
    public void addResources(Resource resource)
    {
        Resources[(int)resource.Type].Value += resource.Value;
    }

    /**
     * Used when the player earns or spends money
     */
    public void addMoney(int amount)
    {
        Money += amount;
    }
    #endregion


    public bool canBuy(Building building)
    {
        for (int i = 0; i < Resource.NB_RESOURCE_TYPES; i++)
            if (Resources[i].Value < building.Costs[i].Value) return false;
        return Money > building.Price;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(0, .5f, 0);
            transform.Rotate(0, 0, .5f);
            rotation = -45;
        }


        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(0, -.5f, 0);
            transform.Rotate(0, 0, .5f);
            rotation = 45;
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(0, .5f, 0);
            transform.Rotate(0, 0, -.5f);
            rotation = -135;
        }


        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(0, -.5f, 0);
            transform.Rotate(0, 0, -.5f);
            rotation = 135;
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, .5f, 0);
            rotation = -90;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, -.5f, 0);
            rotation = 90;
        }


        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, .5f);
            rotation = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(0, 0, -.5f);
            rotation = 180;
        }
        Mesh.transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        //Mesh.transform.LookAt(Orientation.transform, Mesh.transform.up);
    }

}
