using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreDead;
    public int scoreHit;
    public float _currentHealth = 0f;
    public float _maxHealth = 100f;
    private bool rotationDone = false;

    [SerializeField]
    private Rigidbody rb;

    public enum GravityMode { Normal, G0, gravityInversed }
    public GravityMode currentGravity;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Bullet"))
        {
            rotationDone = false;
            Manager._Instance.AddScore(scoreHit);            
            Object.Destroy(other.gameObject);
            _currentHealth -= 10f;
            if (_currentHealth <= 0)
            {
                Manager._Instance.AddScore(scoreDead);
                Object.Destroy(gameObject);
            }
        }

        if (other.tag == ("BulletGravity"))
        {
            rotationDone = false;
            Object.Destroy(other.gameObject);
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * 200f, ForceMode.Force);
            SetGravity(GravityMode.G0);
            this.GetComponent<Rigidbody>().transform.Rotate(0, 1f, 1f);

        }

        if (other.tag == ("BulletInversed"))
        {
            if (currentGravity == GravityMode.gravityInversed)
            {
                if (rotationDone != true)
                {
                    this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler(0, 0, 0), 0.8f);
                    rotationDone = true;
                }
                Object.Destroy(other.gameObject);
                SetGravity(GravityMode.Normal);
            }

            else if (currentGravity == GravityMode.G0)
            {
                Object.Destroy(other.gameObject);
                SetGravity(GravityMode.Normal);
            }
            else
            {
                SetGravity(GravityMode.gravityInversed);
                Object.Destroy(other.gameObject);
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
