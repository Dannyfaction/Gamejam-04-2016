using UnityEngine;
using System.Collections;

public class colectable : MonoBehaviour {

    public Vector3 rotation;
    public float rotationSpeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}

