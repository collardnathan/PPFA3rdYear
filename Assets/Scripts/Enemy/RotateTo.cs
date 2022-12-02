using System;
using UnityEngine;


public class RotateTo : MonoBehaviour
{
    public Transform target;


    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

}
