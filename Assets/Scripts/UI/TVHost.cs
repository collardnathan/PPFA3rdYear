using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVHost : MonoBehaviour
{
    string quote1 = "And that a splash who send him right to hell!";
    string quote2 = "Another survivor who escape the furnace!";
    string quote3 = "What a kill! I looooove it!";
    public Text text;
    bool play;
    bool firstNumberEnemy = false;
    private int alea;
    private float numberEnemies;
    private float lastNumberEnemies;

    private float timer = 20f;
    private float timerText = 3f;


    private void Start()
    {
        play = true;
    }

    private void Update()
    {
        if (firstNumberEnemy == false)
        {
            lastNumberEnemies = Manager._Instance.enemyCount;
            firstNumberEnemy = true;
        }
        numberEnemies = Manager._Instance.enemyCount;

        if (play)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                alea = Random.Range(0, 2);
                StopTimer();
            }
        }
        else if (!play)
        {
            if (timerText > 0)
            {
                timerText -= Time.deltaTime;
                Quotes();
            }
            else
            {
                ResetTimer();
            }                
        }

        if (numberEnemies != lastNumberEnemies)
        {
            StopTimer();
            lastNumberEnemies = numberEnemies;
        }
    }

    private void Quotes()
    {

        if (alea == 0)
        {
            text.text = quote1;
        }
        else if (alea == 1)
        {
            text.text = quote2;
        }
        else
        {
            text.text = quote3;
        }

    }

    public void ResetTimer()
    {       

        if (Manager._Instance.enemyCount <= 12 && Manager._Instance.enemyCount >= 5)
        {
            timer = 30f;
        }
        else if (Manager._Instance.enemyCount <= 5 && Manager._Instance.enemyCount > 1)
        {
            timer = 50f;
        }
        else
        {
            timer = 20f;
        }

        play = true;
        HideText();

    }

    private void HideText()
    {
        text.text = null;
        timerText = 3f;
    }

    public void StopTimer()
    {
        play = false;
    }
}
