using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Manager._Instance.Winner();
        }
    }
}
