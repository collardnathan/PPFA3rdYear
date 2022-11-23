using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    //const float G = 667.4f;

    //public static List<Attraction> Attractors;

    //public Rigidbody rb;

    //private void FixedUpdate()
    //{
    //    Attraction[] attractors = FindObjectsOfType<Attraction>();
    //    foreach (Attraction attractor in Attractors)
    //    {
    //        if (attractor != this)
    //        {
    //            Attract(attractor);
    //        }
    //        Attract(attractor);
    //    }
    //}

    //private void OnEnable()
    //{
    //    if (Attractors == null)
    //        Attractors = new List<Attraction>();

    //    Attractors.Add(this);
    //}

    //private void OnDisable()
    //{
    //    Attractors.Remove(this);
    //}

    //void Attract(Attraction objectToAttract)
    //{
    //    Rigidbody rbToAttract = objectToAttract.rb;

    //    Vector3 direction = rb.position - rbToAttract.position;
    //    float distance = direction.magnitude;

    //    float ForceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
    //    Vector3 force = direction.normalized * ForceMagnitude;
    //    rbToAttract.AddForce(force);
    //}
}
