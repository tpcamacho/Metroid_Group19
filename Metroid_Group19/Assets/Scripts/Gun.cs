using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tyler Camacho and Nataly Vazquez
//11/13/23
//this controls the shooting aspect of the gun

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;

    public GameObject bulletPrefab;

    public int bulletDamage = 1;

    // Update is called once per frame
    void Update()
    {
        //player shoots when pressing space
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
