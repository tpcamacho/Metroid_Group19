using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Material clear;
    public float blinkDuration = 5f;
    private Material teal;
    private Renderer playerRenderer;
    private bool noDamage = false;

    public int HP = 99;

    public float speed = 10f;

    private Rigidbody rigidBodyRef;

    public float jumpforce = 10f;

    public float deathYLevel = -3f;

    private Vector3 startingPos;


    private int easyEnemyDamage = 15;
    private int hardEnemyDamage = 35;
    private int spikeDamage = 10;


    private bool facingRight = true;

    public int keysCollected = 0;


    // Start is called before the first frame update
    void Start()
    {
        //gets the rigidbody component off of the object and stores a reference to it
        rigidBodyRef = GetComponent<Rigidbody>();

        //set the starting position
        startingPos = transform.position;

        playerRenderer = GetComponent<Renderer>();
        teal = playerRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        //moves right and left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (facingRight == true)
            {
                transform.Rotate(Vector3.up * 180);
                facingRight = false;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (facingRight == false)
            {
                transform.Rotate(Vector3.up * 180);
                facingRight = true;
            }
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            HandleJump();
        }


        //player dies if they fall off the game
        if (transform.position.y <= deathYLevel)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Game Ends");
        }

        LosingHP();
    }

    // avoids double jump
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

    //player loses hp and loses if hp is zero
    private void LosingHP()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Game Ends");
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        //player teleports to another position
        if (other.gameObject.tag == "Portal")
        {
            startingPos = other.gameObject.GetComponent<Portal>().teleportPoint.transform.position;
            transform.position = startingPos;
        }

        //player loses health from easy enemy
        if (other.gameObject.tag == "EasyEnemy")
        {
            HP -= easyEnemyDamage;
            StartCoroutine(BlinkEffect());
        }

        //player loses health from hard enemy
        if (other.gameObject.tag == "HardEnemy")
        {
            HP -= hardEnemyDamage;
            StartCoroutine(BlinkEffect());
        }

        if (other.gameObject.tag == "spike")
        {
            HP -= spikeDamage;
            StartCoroutine(BlinkEffect());
        }

        //player gets 100 hp
        if (other.gameObject.tag == "Health")
        {
            HP = 100;

            Destroy(other.gameObject);
        }

        //player gets extra hp
        if (other.gameObject.tag == "Extra")
        {
            HP += 15;

            Destroy(other.gameObject);
        }

        // players gets key
        if (other.gameObject.tag == "Key")
        {
            Debug.Log("Collided with a key");
            keysCollected++;
            other.gameObject.SetActive(false);
        }
        if (!noDamage && other.CompareTag("EasyEnemy"))
        {
            StartCoroutine(BlinkEffect());
        }
        if (!noDamage && other.CompareTag("HardEnemy"))
        {
            StartCoroutine(BlinkEffect());
        }
        if (!noDamage && other.CompareTag("spike"))
        {
            StartCoroutine(BlinkEffect());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // damage from easy enemy
        if (collision.gameObject.tag == "EasyEnemy")
        {
            HP -= easyEnemyDamage;
            StartCoroutine(BlinkEffect());
        }

        // damaage from hard enemy
        if (collision.gameObject.tag == "HardEnemy")
        {
            HP -= hardEnemyDamage;
            StartCoroutine(BlinkEffect());
        }

        //check to see if key is needed or not to open door
        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("Collide with door");

            Door collidedDoor = collision.gameObject.GetComponent<Door>();

            if (keysCollected >= collidedDoor.keyRequired)
            {
                collision.gameObject.SetActive(false);
                keysCollected -= collidedDoor.keyRequired;
            }
            else
            {
                Debug.Log("You need a key!");
            }
        }
    }

    IEnumerator BlinkEffect()
    {
        noDamage = true;

        playerRenderer.material = clear;

        yield return new WaitForSeconds(blinkDuration);

        playerRenderer.material = teal;
        noDamage = false;
    }


    /*

    private void Blink()
    {
        if (canTakeDamage)
        {
            StartCoroutine(SetInvincible());
        }
    }
        
    /*

    public IEnumerator Blink()
    {
        for(int Index = 0; Index < 30; Index++)
        {
            if (Index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            yield return new WaitForSeconds(5f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }
    */

    private void RotatePlayerModel(float angle)
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.y = angle;
        transform.rotation = Quaternion.Euler(currentRotation);

    }

    /*
    //look at unit 17 coroutines example
    IEnumerator SetInvincible()
    {
        canTakeDamage = false;

        float binkDuration = 5f;
        float blinkSpeed = 0.2f;
        float elapsedTime = 0f;

        while (elapsedTime < binkDuration)
        {
            SetRenderersVisibility(!AreRenderersVisible());
            yield return new WaitForSeconds(blinkSpeed);
            elapsedTime += blinkSpeed;
        }

        SetRenderersVisibility(true);
        canTakeDamage = true;
    }

    private void SetRenderersVisibility(bool visible)
    {  
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = visible;
        }
    }

    private bool AreRenderersVisible()
    {  
        foreach (Renderer renderer in renderers)
        {
            if (renderer.enabled)
            {
                return true;
            }
        }
        return false;
    }   

    */
}
