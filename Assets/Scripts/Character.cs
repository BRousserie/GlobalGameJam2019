using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Resource[] m_resources = new Resource[Resource.NB_RESOURCE_TYPES]; // resources owned by the player
    public Resource[] Resources { get { return m_resources; } }
    private int m_money; // money possessed by the player
    public int Money { get { return m_money; } }

    public Character(Resource[] resources = null, int money = 0)
    {
        m_resources = resources;
        money = 0;
    }

    #region get/set/add resources and money
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
     * Used to set one type of resources without constructing a resource
     */
    public void setResources(ResourceType type, int value)
    {
        m_resources[(int)type].Value = value;
    }

    /**
     * Used when the player recieves or loses resources 
     * resource.Value is negative when losing resources
     */
    public void addResources(Resource resource)
    {
        m_resources[(int)resource.Type].Value += resource.Value;
    }

    /**
     * Used when the player earns or spends money
     */
    public void addMoney(int amount)
    {
        m_money += amount;
    }
    #endregion


    public bool canBuy(Building building)
    {
        for (int i = 0; i < Resource.NB_RESOURCE_TYPES; i++)
            if (m_resources[i].Value < building.Costs[i].Value) return false;
        return m_money > building.Price;
    }
}
