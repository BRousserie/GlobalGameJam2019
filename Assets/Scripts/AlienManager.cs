using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public Transform pivot;
    WaitForSeconds wfsg = new WaitForSeconds(1f);
    WaitForSeconds wfsd = new WaitForSeconds(0.1f);
    Vector3 rotation = Vector3.zero;

    public void initAlien()
    {
        rotation.y = Random.Range(-90f, 90f);
        rotation.z = Random.Range(-90f, 90f);
        pivot.Rotate(rotation);
        rotation = Vector3.zero;
        StartCoroutine(generationRandom());
        StartCoroutine(deplacement());
        
    }

    IEnumerator generationRandom()
    {
        while (true)
        {
            yield return wfsg;
            rotation.y = Random.Range(-1.5f, 1.5f);
            rotation.z = Random.Range(-1.5f, 1.5f);
            wfsg = new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    IEnumerator deplacement()
    {
        while (true)
        {
            yield return wfsd;
            pivot.Rotate(rotation);
        }
    }
}
