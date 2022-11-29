using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _Instance;

    public int Score;

    private void Update()
    {
        print(Score);
    }
    private void Awake()
    {
        if (_Instance != null)
        {
            return;
        }
        _Instance = this;
    }

    public void AddScore(int score)
    {
        Score += score;
    }
}
