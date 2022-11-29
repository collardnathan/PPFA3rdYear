using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_MoveToPlayer : MonoBehaviour
{
    public Transform player;
    public float _speed;
    public float minimumAttack;
    //public GameObject projectile;
    private enum States { Patrol, Follow, Attack}
    private States states;


    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > minimumAttack)
        {
            //Run to the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
        }
        else
        {
            // Attack the player
        }
    }
}
