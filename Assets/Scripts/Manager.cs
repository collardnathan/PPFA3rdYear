using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager _Instance;

    public int Score;

    public PlayerMovement player;

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

    public void HealthPlayer(int damages)
    {
        if (player.GetComponent<PlayerMovement>()._health <= 0 )
        {

        }
        player.GetComponent<PlayerMovement>()._health -= damages;
        print(player.GetComponent<PlayerMovement>()._health);
    }
}
