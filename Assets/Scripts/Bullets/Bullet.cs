using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start()
    {
        Object.Destroy(gameObject, 2.5f);
    }

    private void FixedUpdate()
    {
        print(GetComponent<CapsuleCollider>().transform.position);
        print(this.gameObject.transform.position);
    }
}
