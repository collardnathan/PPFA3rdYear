using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Enemy enemy;
    public GameObject projectile;
    public Transform[] patrolPoints;
    public Transform muzzle;
    public Transform player;
    public float timeBetweenShots;
    private float nextShotTime;
    public float minimumAttackDistance;
    public float minimumPatrolingDistance;
    public float waitTime;
    public float _speed;
    public int currentPointIndex;
    private enum States { Idling, Patroling, Shoting }
    private States states;
    bool once;


    private void Start()
    {
        enemy = enemy.GetComponent<Enemy>();
    }

    private void Update()
    {
        if (enemy.currentGravity != Enemy.GravityMode.Normal)
        {
            states = States.Idling;
        }
        else if (Vector3.Distance(transform.position, player.position) > minimumPatrolingDistance)
        {
            states = States.Patroling;
        }
        else if (Vector3.Distance(transform.position, player.position) < minimumPatrolingDistance)
        {
            states = States.Shoting;
        }
    }

    private void FixedUpdate()
    {
        switch (states)
        {
            case States.Idling:
                break;
            case States.Patroling:
                if (transform.position != patrolPoints[currentPointIndex].position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, _speed * Time.deltaTime);
                }
                else
                {
                    if (once == false)
                    {
                        once = true;
                        StartCoroutine(Wait());
                    }
                }
                break;
            case States.Shoting:
                if (Vector3.Distance(transform.position, player.position) > minimumAttackDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
                }
                else
                {
                    if (Time.time > nextShotTime)
                    {
                        Instantiate(projectile, muzzle.transform.position, Quaternion.identity);
                        nextShotTime = Time.time + timeBetweenShots;
                    }

                    if (Vector3.Distance(transform.position, player.position) < minimumAttackDistance)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, player.position, -_speed * Time.deltaTime);
                    }
                }
                break;
            default:
                break;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }
}
