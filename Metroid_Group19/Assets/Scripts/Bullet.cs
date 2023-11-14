using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tyler Camacho and Nataly Vazquez
//11/13/23
//this script controls the bullet movement and damage to enemies

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public int damage = 1;

    public Rigidbody rigidBody;

   

    // Start is called before the first frame update
    void Start()
    {
        //bullet movement
        rigidBody.velocity = transform.right * speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        //easy enemy takes damage when hit with bullet
        EasyEnemy easyEnemy = other.GetComponent<EasyEnemy>();
        if (easyEnemy != null)
        {
            easyEnemy.takeDamage(damage);
        }

        //hard enemy takes damage when hit with bullet
        HardEnemy hardEnemy = other.GetComponent<HardEnemy>();
        if (hardEnemy != null)
        {
            hardEnemy.takeDamage(damage);
        }

        Destroy(gameObject);
    }

}
