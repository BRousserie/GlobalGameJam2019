using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public bool started = true;
    public Transform planete;
    private WaitForSeconds wfs = new WaitForSeconds(1f);

    public GameObject[] alienPrefabs;

    int nbAliens = 0;

    IEnumerator spawner()
    {
        while (started)
        {
            yield return wfs;
            int numPrefabAlien = Random.Range(0, alienPrefabs.Length);
            GameObject alien = Instantiate(alienPrefabs[numPrefabAlien], transform.position, Quaternion.identity);
            nbAliens++;
            GameObject pivotAlien = new GameObject("Pivot_Alien_"+nbAliens);
            pivotAlien.transform.parent = planete.transform;
            pivotAlien.transform.localPosition = Vector3.zero;
            alien.transform.parent = pivotAlien.transform;
            AlienManager tmp = alien.GetComponent<AlienManager>();
            tmp.pivot = pivotAlien.transform;
            tmp.initAlien();

            Vector3 normale = (alien.transform.position - pivotAlien.transform.position).normalized;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normale);
            alien.transform.rotation = rotation;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }
}
