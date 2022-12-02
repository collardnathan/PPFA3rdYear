using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    public float regenHealthValue;
    private float playerHealth;
    private float maxHealth;

    public void Update()
    {
        float playerHealth = Manager._Instance.player._health;
        float maxHealth = Manager._Instance.player._maxHealth;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Manager._Instance.player._health < Manager._Instance.player._maxHealth)
            {
                if (Manager._Instance.player._health + regenHealthValue > Manager._Instance.player._maxHealth)
                {
                    Manager._Instance.player._health = Manager._Instance.player._maxHealth;
                }
                else
                {
                    Manager._Instance.player._health +=  regenHealthValue;
                }
            }            
        }
    }
}
