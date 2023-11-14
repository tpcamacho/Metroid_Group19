using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : MonoBehaviour
{
    public float travelDistanceRight = 0;
    public float travelDistanceLeft = 0;
    public float speed;

    private float startingX;
    private bool movingRight = true;

    public int easyEnemyHP = 1;
    public int bulletDamage = 1;


    // Start is called before the first frame update
    void Start()
    {
        //when the scene starts, store the initial X value of this object
        startingX = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            //if the object is not farther than the start position + right travel dist, it can move right 
            if (transform.position.x <= startingX + travelDistanceRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                movingRight = false;
            }

        }
        else
        {
            //if obj is not farther than the start position + left travel dist, it can move left 
            if (transform.position.x >= startingX + travelDistanceLeft)
            {
                //if obj goes too far left, tell it to move right
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            //if obj goes too far left, tell it to move right
            else
            {
                movingRight = true;
            }
        }
    }

    

    public void takeDamage (int damage)
    {
        easyEnemyHP -= damage;
        if (easyEnemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            easyEnemyHP -= bulletDamage;

        }
        if (other.gameObject.tag == "Player")
        {
            easyEnemyHP -= bulletDamage;

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HardEnemy")
        {
            easyEnemyHP -= bulletDamage;
        }
    }


}
