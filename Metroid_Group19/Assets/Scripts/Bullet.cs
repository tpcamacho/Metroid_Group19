using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public int damage = 1;

    public Rigidbody rigidBody;

   

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = transform.right * speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        EasyEnemy easyEnemy = other.GetComponent<EasyEnemy>();
        if (easyEnemy != null)
        {
            easyEnemy.takeDamage(damage);
        }

        HardEnemy hardEnemy = other.GetComponent<HardEnemy>();
        if (hardEnemy != null)
        {
            hardEnemy.takeDamage(damage);
        }

        Destroy(gameObject);
    }

}
