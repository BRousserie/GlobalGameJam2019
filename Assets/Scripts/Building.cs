using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    private Resource[] m_costs; // building costs by resource type
    public Resource[] Costs { get { return m_costs; } }
    private int m_price; // building price
    public int Price { get { return m_price; } }

    public Building(Resource[] costs, int price)
    {
        m_costs = (costs != null) ? costs
            : new Resource[Resource.NB_RESOURCE_TYPES];
        m_price = price;
    }
}
