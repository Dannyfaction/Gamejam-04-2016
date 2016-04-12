using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private float speed = 5f;
    private float boostLeft = 2;
    public float BoostLeft
    {
        get { return boostLeft; }
    }
    public float Speed
    {
        get { return speed; }
    }
    private Vector3 playerRot;
    private Vector3 movementVector = Vector3.zero;
    private Vector3 oldVector = Vector3.zero;
    private float xAngle;
    private float yAngle;
    private float zAngle;
    private float initialSpeed;
    private Vector3 initialPosition;
    private float boostTimer = 0;

    void Start()
    {
        initialSpeed = speed;
        initialPosition = transform.position;
    }

    void Update()
    {
        playerRot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void FixedUpdate()
    {
        boostTimer--;
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

        //For moving up and down
        else if (Input.GetAxis("Vertical") > 0)
        {
            xAngle = 1;
            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 82)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 80);
            }
        }

        //For moving up and down
        else if (Input.GetAxis("Vertical") < 0)
        {
            xAngle = -1;

            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 90)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 80);
            }
        }

        //For moving left and right
        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.Rotate(new Vector3(0, 1.5f, 0), Space.World);
            transform.Rotate(new Vector3(0f, 0f, -2.5f), Space.Self);

            if (transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z < 280)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 280);
            }
        }

        //For moving left and right
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.Rotate(new Vector3(0, -1.5f, 0), Space.World);
            transform.Rotate(new Vector3(0f, 0f, 2.5f), Space.Self);

            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 180)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 80);
            }
        }

        //Rotating the plane back to its original rotation
        else if (Input.GetAxis("Horizontal") == 0f)
        {
            if (transform.rotation.eulerAngles.z < 358 && transform.rotation.eulerAngles.z > 270)
            {
                transform.Rotate(new Vector3(0, 0, 2) * 2, Space.Self);
            }
            else if (transform.rotation.eulerAngles.z > 2 && transform.rotation.eulerAngles.z < 90)
            {
                transform.Rotate(new Vector3(0, 0, -2) * 2, Space.Self);
            }
        }

        //Once the boost has been activated
        if (Input.GetAxis("Jump") > 0f || Input.GetAxis("RightTrigger") > 0f)
        {
            if (boostLeft > 0 && boostTimer <= 0)
            {
                speed = 10f;
                boostTimer = 200;
                boostLeft--;
                Invoke("ReduceSpeed", 3f);
            }
        }

        movementVector = this.transform.position - oldVector;
    }

    //Showing the Level once close to it
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube")
        {
            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();
            meshRenderer.enabled = true;
        }
    }

    //Hiding the Level once not close anymore
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Cube")
        {
            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }
    }

    //Resetting the position, rotation and Boosts once you have crashed into the level
    void OnCollisionEnter(Collision other)
    {
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        boostLeft = 2;
    }

    //Reducing the speed once boost is over
    void ReduceSpeed()
    {
        speed = initialSpeed;
    }
}