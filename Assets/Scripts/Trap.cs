using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damages;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Manager._Instance.player._health > 0)
            {
                Manager._Instance.player._health -= damages * Time.deltaTime;
            }
            else
            {
                Manager._Instance.Death();
            }
        }
    }
}
