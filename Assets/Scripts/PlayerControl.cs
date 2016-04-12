using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private float speed = 3f;
    private Vector3 playerRot;
    private Vector3 movementVector = Vector3.zero;
    private Vector3 oldVector = Vector3.zero;
    private float xAngle;
    private float yAngle;
    private float zAngle;

    void Update()
    {
        playerRot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void FixedUpdate()
    {
        oldVector = this.transform.position;
        transform.position += transform.forward * Time.deltaTime * speed;

        /*
        if (transform.rotation.eulerAngles.x > 20 && transform.rotation.eulerAngles.x <= 180)
        {
            xAngle = 0;
        }
        else if (transform.rotation.eulerAngles.x < 340 && transform.rotation.eulerAngles.x > 180)
        {
            xAngle = 0;
        }
        */

        transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x + xAngle,transform.rotation.eulerAngles.y + yAngle,transform.rotation.eulerAngles.z + zAngle);

        if (Input.GetAxis("Vertical") == 0)
        {
            xAngle = 0;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            //go up
            xAngle = 1;
            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 82)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 80);
            }
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            //go down
            xAngle = -1;

            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 90)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 80);
            }
        }

        //rotate plane banking
        if (Input.GetAxis("Horizontal") > 0f)
        {
            //bank & turn right
            transform.Rotate(new Vector3(0, 1.5f, 0), Space.World);
            transform.Rotate(new Vector3(0f, 0f, -2.5f), Space.Self);

            if (transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z < 280)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 280);
            }
        }
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            //bank & turn left
            transform.Rotate(new Vector3(0, -1.5f, 0), Space.World);
            transform.Rotate(new Vector3(0f, 0f, 2.5f), Space.Self);

            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 180)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 80);
            }
        }
        else if (Input.GetAxis("Horizontal") == 0f)
        {
            //rotate plane back to 0 over Z axis
            if (transform.rotation.eulerAngles.z < 358 && transform.rotation.eulerAngles.z > 270)
            {
                //if plane is rotated to the right
                transform.Rotate(new Vector3(0, 0, 2) * 2, Space.Self);
            }
            else if (transform.rotation.eulerAngles.z > 2 && transform.rotation.eulerAngles.z < 90)
            {
                //if plane is rotated to the left
                transform.Rotate(new Vector3(0, 0, -2) * 2, Space.Self);
            }
        }

        movementVector = this.transform.position - oldVector;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube")
        {
            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();
            meshRenderer.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Cube")
        {
            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }
    }
}