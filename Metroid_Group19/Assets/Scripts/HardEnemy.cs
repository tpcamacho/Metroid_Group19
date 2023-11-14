using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tyler Camacho and Nataly Vazquez
//11/13/23
//this script controls the hard enemy's movements and damage

public class HardEnemy : MonoBehaviour
{
    private Transform enemy;
    public float speed;
    public int hardEnemyHP = 10;
    public int bulletDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(enemy.transform.position, transform.position) < 7)
        {
            Vector2 target = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
            target.y = transform.position.y;
            transform.position = target;
        }
    }


    // enemy takes damage until they die if hp goes to zero
    public void takeDamage(int damage)
    {
        hardEnemyHP -= damage;
        if (hardEnemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /*
    private void damageHealth()
    {
        hardEnemyHP = hardEnemyHP -= bulletDamage;
        if (hardEnemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        //enemy takes damage from bullet
        if (other.gameObject.tag == "bullet")
        {
            hardEnemyHP -= bulletDamage;

        }

        //enemy takes damage from bullet
        if (other.gameObject.tag == "Player")
        {
            hardEnemyHP -= bulletDamage;

        }
    }

    //enemy takes damage from bullet
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HardEnemy")
        {
            hardEnemyHP -= bulletDamage;
        }
    }
}

