using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Text : MonoBehaviour
{
    public Text Score;

    void Start()
    {
        Score.text = (("ID PLAYER 15248336 Final Score : ") + Manager._Instance.Score);
    }

}
