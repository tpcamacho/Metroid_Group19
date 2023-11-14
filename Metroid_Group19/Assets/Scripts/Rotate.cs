using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tyler Camacho and Nataly Vazquez
//11/13/23
// this controls the camera movement

public class Rotate : MonoBehaviour
{

    public GameObject Player;
    Vector3 offset;

    //all prevents camera from rotating with character
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Player.transform.position;
        this.transform.position += offset;
    }
}
