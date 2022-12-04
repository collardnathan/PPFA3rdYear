using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField]
    //LayerMask layer;

    private void Start()
    {
        Object.Destroy(gameObject, 2.5f);
    }

    private void Update()
    {

        //RaycastHit hit;

        //if (Physics.CapsuleCast(transform.localPosition - new Vector3(0, 0, 1.18f), transform.localPosition + new Vector3(0, 0, 1.18f), 0.62f, transform.localPosition, out hit, layer))
        //{
        //    print(hit.collider.gameObject);
        //    Object.Destroy(gameObject);
        //}
    }

   
}
