using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int HP = 99;
    
    public float speed = 10f;

    private Rigidbody rigidBodyRef;

    public float jumpforce = 10f;

    public float deathYLevel = -3f;

    private Vector3 startingPos;


    private int easyEnemyDamage = 15;
    private int hardEnemyDamage = 35;

    private bool canTakeDamage = true;


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
            transform.Rotate(Vector3.up * 180);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.Rotate(Vector3.up * 180);
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            HandleJump();
        }



        if (transform.position.y <= deathYLevel)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Game Ends");
        }

        GameOver();
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

    //attempt failed
    private void GameOver()
    {
         if (HP <= 0)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Game Ends");
        }
    }
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Portal")
        {
            startingPos = other.gameObject.GetComponent<Portal>().teleportPoint.transform.position;
            transform.position = startingPos;
        }
        if (other.gameObject.tag == "EasyEnemy")
        {
            HP -= easyEnemyDamage;
        }
        if (other.gameObject.tag == "HardEnemy")
        {
            HP -= hardEnemyDamage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EasyEnemy")
        {
            HP -= easyEnemyDamage;
        }
    }


    //look at unit 17 coroutines example
    IEnumerator SetInvicible()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(5f);
        canTakeDamage = true;
    }
}
