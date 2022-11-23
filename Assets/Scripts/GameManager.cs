using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    public Vector3 gravity = new Vector3(50, 9.81f, 50);
    public GameObject myObjects;
    public Rigidbody rb;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        ApplyForceGravity(myObjects);
    }

    private void ApplyForceGravity(GameObject currentActor)
    {
        GameObject[] allActors = Object.FindObjectsOfType<GameObject>();
        foreach (GameObject all in allActors)
        {
            currentActor = all;
            
            if (currentActor.GetComponent<Rigidbody>() != null)
            {
                currentActor.GetComponent<Rigidbody>().AddForce(gravity, ForceMode.VelocityChange);
                currentActor.GetComponent<Rigidbody>().useGravity = false;
            }
            
            
        }

    }
}
