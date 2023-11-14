using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (other.gameObject.tag == "bullet")
        {
            /*
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
            */
            hardEnemyHP -= bulletDamage;

        }
        if (other.gameObject.tag == "Player")
        {
            /*
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
            */
            hardEnemyHP -= bulletDamage;

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HardEnemy")
        {
            hardEnemyHP -= bulletDamage;
        }
    }
}

