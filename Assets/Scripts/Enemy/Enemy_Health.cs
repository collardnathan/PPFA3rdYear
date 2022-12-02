using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public GameObject healthBar;
    public Slider slider;
    private Enemy enemy;

    private void Start()
    {
        slider.value = CalculateHealth();
        
    }

    private void Update()
    {
        slider.value = CalculateHealth();
    }

    float CalculateHealth()
    {
        enemy = GetComponent<Enemy>();
        return enemy._currentHealth / enemy._maxHealth;
    }
}
