using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _currentHealth = 0f;
    public float _maxHealth = 100f;

    [SerializeField]
    private Rigidbody rb;

    public enum GravityMode { Normal, G0, gravityInversed }
    private GravityMode currentGravity;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
          
        if (other.tag == ("Bullet"))
        {
            print("Bullet");
            _currentHealth -= 10f;
            Object.Destroy(other.gameObject);
            if (_currentHealth <= 0)
            {
                Object.Destroy(gameObject);
            }
        }

        if (other.tag == ("BulletGravity"))
        {
            print("Gravity");
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * 200f, ForceMode.Force);
            SetGravity(GravityMode.G0);
            this.GetComponent<Rigidbody>().transform.Rotate(0, 1f, 1f);

        }

        if (other.tag == ("BulletInversed"))
        {
            if (currentGravity == GravityMode.gravityInversed)
            {
                SetGravity(GravityMode.Normal);

            }

            else if (currentGravity == GravityMode.G0)
            {
                SetGravity(GravityMode.Normal);
            }
            else
            {
                SetGravity(GravityMode.gravityInversed);
            }
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
