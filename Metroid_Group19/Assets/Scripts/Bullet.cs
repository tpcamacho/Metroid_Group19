using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public int damage = 1;

    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EasyEnemy easyEnemy = hitInfo.GetComponent<EasyEnemy>();
        if (easyEnemy != null)
        {
            easyEnemy.takeDamage(damage);
        }

        HardEnemy hardEnemy = hitInfo.GetComponent<HardEnemy>();
        if (hardEnemy != null)
        {
            hardEnemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
