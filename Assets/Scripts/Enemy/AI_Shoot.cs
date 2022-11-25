using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Shoot : MonoBehaviour
{
    public Transform player;
    public float _speed;
    public float minimumAttack;

    public GameObject projectile;
    public float timeBetweenShots;
    private float nextShotTime;
    public Transform muzzle;

    private void Update()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(projectile, muzzle.transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }

        if (Vector3.Distance(transform.position, player.position) < minimumAttack)
        {
            //Run to the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, -_speed * Time.deltaTime);
        }

    }
}
