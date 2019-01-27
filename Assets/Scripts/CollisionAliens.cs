using UnityEngine;

public class CollisionAliens : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("alien"))
        {
            Destroy(other.transform.parent.gameObject);
            Destroy(this.transform.transform.parent.gameObject);
        }
    }

}
