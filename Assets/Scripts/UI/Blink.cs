using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public float minTime = 0.05f;
    public float maxTime = 1.2f;


    private float timer;
    public Text textFlicker;

    private void Start()
    {
        textFlicker = GetComponent<Text>();
        timer = 1f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            textFlicker.enabled = !textFlicker.enabled;
            timer = 1f;
        }
    }
}
