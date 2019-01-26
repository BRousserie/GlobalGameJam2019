using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commercial : Building
{
    private int m_outcome; // outcomes of the commercial activity (money)
    public int Outcome { get { return m_outcome; } }

    public Commercial(Resource[] costs, int price, int outcome)
        : base(costs, price)
    {
        m_outcome = outcome;
    }
}
