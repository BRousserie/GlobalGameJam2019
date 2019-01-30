using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLookAtCam : MonoBehaviour
{
    Transform cam;
    Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;// GameObject.FindObjectOfType<Character>().transform;
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.LookAt(cam, cam.up);
    }
}
