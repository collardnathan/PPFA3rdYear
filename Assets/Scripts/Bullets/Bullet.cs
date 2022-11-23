using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start()
    {
        Object.Destroy(gameObject, 2.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == ("Wall"))
        //{
        //    Object.Destroy(other.gameObject);
        //    Object.Destroy(gameObject);
        //    print(other);
        //}

        //if (other.gameObject.tag == ("Enemy"))
        //{

        //}
    }

}
