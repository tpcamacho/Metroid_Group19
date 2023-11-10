using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;

    public GameObject bulletPrefab;

    public int bulletDamage = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //shoot bullets

        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
