using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardEnemy : MonoBehaviour
{
    private Transform enemy;
    public float speed;

    public int hardEnemyHP = 10;

    private int bullletDamage = 1;

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

  
 


    private void LosingHP()
    {


        if (hardEnemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    
}


