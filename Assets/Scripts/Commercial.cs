using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commercial : Building
{
    public int Outcome; // outcomes of the commercial activity (money)
    private WaitForSeconds wfs;
    public float Delay;
    public Character Player;

    private void Start()
    {
        wfs = new WaitForSeconds(Delay);
        StartCoroutine(outcome());
    }

    private IEnumerator outcome()
    {
        while (true)
        {
            yield return wfs;
            Player.addResources(ResourceType.Money, Outcome);
        }
    }
}
