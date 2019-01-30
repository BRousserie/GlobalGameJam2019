using System.Collections;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public Transform pivot;
    public Transform armePivot;
    public Transform shootOrigin;
    public Transform collision;
    public int Health = 20;
    WaitForSeconds wfsg = new WaitForSeconds(1f);
    WaitForSeconds wfsd = new WaitForSeconds(0.1f);
    WaitForSeconds wfst = new WaitForSeconds(5f);
    WaitForSeconds wfstd = new WaitForSeconds(.5f);
    WaitForSeconds wfsReactivateMove = new WaitForSeconds(1f);
    Vector3 rotation = Vector3.zero;
    public GameObject projectile;
    Building target;
    public ParticleSystem bzzz;

    public Transform buildingOverlapCenter;
    public LayerMask buildingOverlapLayeMask;

    bool canMove = true;

    // On stocke le transform pour des raisons de performance
    Transform _transform;

    public void initAlien()
    {
        _transform = transform;
        rotation.y = Random.Range(0f, 360f);
        rotation.z = Random.Range(0f, 360f);
        pivot.Rotate(rotation);
        collision.SetParent(pivot.transform);
        rotation = Vector3.zero;
        StartCoroutine(generationRandom());
        StartCoroutine(deplacement());
        StartCoroutine(tir());
    }

    IEnumerator generationRandom()
    {
        while (true)
        {
            yield return wfsg;
            rotation.y = Random.Range(-50f, 50f);
            rotation.z = Random.Range(-50f, 50f);
            wfsg = new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    IEnumerator deplacement()
    {
        while (true)
        {
            yield return wfsd;
            if(canMove)
                pivot.Rotate(rotation * Time.deltaTime);
        }
    }

    IEnumerator tir()
    {
        while (true)
        {
            yield return wfst;
            FindTarget();
            if (target != null)
            {
                canMove = false;

                bzzz.Play();

                StartCoroutine(delayedSoot());
            }
        }
    }

    IEnumerator delayedSoot()
    {
        yield return wfstd;
        if (target != null)
        {
            Vector3 direction = (shootOrigin.position - target.transform.position).normalized;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, direction);
            GameObject bullet = Instantiate(projectile, shootOrigin.position, shootOrigin.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(direction * (-300f));
            StartCoroutine(moveReactivation());
        }        
    }

    IEnumerator moveReactivation()
    {
        yield return wfsReactivateMove;
        canMove = true;
    }

    private void FindTarget()
    {
        target = null;
        Collider[] colliders = Physics.OverlapSphere(buildingOverlapCenter.position, .4f, buildingOverlapLayeMask);

        if (colliders.Length > 0)
        {
            target = colliders[0].GetComponent<Building>();
            LookAtTarget();
        }
    }

    void LookAtTarget()
    {
        armePivot.LookAt(target.transform, _transform.up);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(buildingOverlapCenter.position, .4f);
    }
}
