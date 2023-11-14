using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    public float blinkInterval = 1f; // Adjust the interval between blinks
    private bool isBlinking = false;
    private Renderer component;

    void Start()
    {
        component = GetComponent<Renderer>();
        if (component == null)
        {
            Debug.LogError("Renderer component not found on the player object.");
            enabled = false; // Disable the script if the renderer is not found
        }

        // Start the blinking coroutine
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);
            isBlinking = !isBlinking;
            component.enabled = isBlinking;
        }
    }
}
