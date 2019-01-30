using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    Transform _transform;
    Vector3 rotation = new Vector3(0f, 15f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Rotate(rotation * Time.deltaTime);
    }
}
