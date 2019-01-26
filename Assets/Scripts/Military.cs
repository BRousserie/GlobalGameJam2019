using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military : Building
{
    private int m_damages; // damages inflicted by the building
    public int Damages { get { return m_damages; } }

    public Military(Resource[] costs, int price, int damages)
        : base(costs, price)
    {
        m_damages = damages;
    }
}
