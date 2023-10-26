using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rigidBodyRef;

    public float jumpforce = 10f;

    public float deathYLevel = -3f;

    private Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        //gets the rigidbody component off of the object and stores a reference to it
        rigidBodyRef = GetComponent<Rigidbody>();

        //set the starting position
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //moves right and left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            HandleJump();
        }
    }

    private void HandleJump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            Debug.Log("Player is touching the ground so jump");
            rigidBodyRef.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Player is not touching the ground so they can't jump");
        }
    }
}