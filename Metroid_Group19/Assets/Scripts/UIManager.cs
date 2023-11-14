using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Tyler Camacho and Nataly Vazquez
//11/13/23
// this displays the hp levels
public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text HPText;
    
    // Update is called once per frame
    void Update()
    {
        //text shows hp levels
        HPText.text = "HP: " + playerController.HP;
    }
}
