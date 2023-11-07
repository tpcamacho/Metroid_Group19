using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    private Transform enemy;
    public float speed;

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
        
        //Restrictions();
    }

    /*
    private void Restrictions()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 40f, 50f), transform.position.y, transform.position.z);
    }
    */
}


