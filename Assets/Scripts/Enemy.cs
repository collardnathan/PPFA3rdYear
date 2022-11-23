using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _health = 100f;
    Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
          
        if (other.tag == ("Bullet"))
        {
            print("Bullet");
            _health -= 10f;
            Object.Destroy(other.gameObject);
            if (_health <= 0)
            {
                Object.Destroy(gameObject);
            }
        }

        if (other.tag == ("BulletGravity"))
        {
            print("Gravity");
        }
    }
}
