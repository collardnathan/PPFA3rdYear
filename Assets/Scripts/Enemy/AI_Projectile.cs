using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Projectile : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;
    PlayerMovement player;
    public int _damages = 10;

    private void Awake()
    {
        targetPosition = FindObjectOfType<PlayerMovement>().transform.position;
        
    }

    private void Start()
    {
        Object.Destroy(gameObject, 1f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Manager._Instance.HealthPlayer(_damages);
            Object.Destroy(this.gameObject);
        }
    }
}
