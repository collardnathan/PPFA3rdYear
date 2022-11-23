using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _health = 100f;

    [SerializeField]
    private Rigidbody rb;

    public enum GravityMode { Normal, G0, gravityInversed }
    private GravityMode currentGravity;


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
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * 200f, ForceMode.Force);
            this.GetComponent<Rigidbody>().AddForce(this.transform.right * 100f, ForceMode.Force);
            SetGravity(GravityMode.G0);

        }

        if (other.tag == ("BulletInversed"))
        {
            print("Inversed");
            SetGravity(GravityMode.gravityInversed);
        }
    }

    private void FixedUpdate()
    {
        switch (currentGravity)
        {
            case GravityMode.Normal:
                Vector3 velocityNormal = rb.velocity;
                velocityNormal += Physics.gravity.normalized * Time.deltaTime;
                rb.velocity = velocityNormal;
                break;
            case GravityMode.G0:
                Vector3 velocityG0 = rb.velocity;
                velocityG0 = velocityG0 + Physics.gravity.normalized - Physics.gravity.normalized;
                rb.velocity = velocityG0;
                break;
            case GravityMode.gravityInversed:
                Vector3 velocityInversed = rb.velocity;
                velocityInversed -= Physics.gravity.normalized * Time.deltaTime;
                rb.velocity = velocityInversed;
                break;
            default:
                break;
        }
    }

    public void SetGravity(GravityMode gravity)
    {
        currentGravity = gravity;
    }
}
