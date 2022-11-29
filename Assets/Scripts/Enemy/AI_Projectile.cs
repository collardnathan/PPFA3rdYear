using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Projectile : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;
    PlayerMovement player;

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
            player = player.GetComponent<PlayerMovement>();            
            player.GetComponent<PlayerMovement>()._health -= 10;
            print(player.GetComponent<PlayerMovement>()._health);
            Object.Destroy(this.gameObject);
        }
    }
}
