using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Count_Enemies : MonoBehaviour
{
    float enemyCount;
    public TMP_Text textEnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        Enemy[] components = GameObject.FindObjectsOfType<Enemy>();
        enemyCount = components.Length;
        textEnemyCount.text = ("" + enemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
