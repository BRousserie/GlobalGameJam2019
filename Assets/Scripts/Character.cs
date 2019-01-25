using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Resource[] m_resources = new Resource[Resource.NB_RESOURCE_TYPES];
    public Resource[] Resources { get { return m_resources; } }

    public void setResources(ResourceType type, int value)
    {
        m_resources[(int)type].Value = value;
    }

    /**
     * Used to set the whole resources' array 
     */
    public void setResources(Resource[] resources)
    {
        if (resources.Length == Resource.NB_RESOURCE_TYPES)
            m_resources = resources;
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
        m_resources[(int)resource.Type].Value = resource.Value;
    }

    /**
     * Used when the player recieves or loses resources 
     * resource.Value is negative when losing resources
     */
    public void addResources(Resource resource)
    {
        m_resources[(int)resource.Type].Value += resource.Value;
    }
}
