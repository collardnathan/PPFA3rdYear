using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    public float gravity;
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
    public void ApplyForceGravity(GameObject currentActor)
    {
        GameObject[] allActors = Object.FindObjectsOfType<GameObject>();
        foreach (GameObject all in allActors)
        {
            currentActor = all;
            
            if (currentActor.GetComponent<Rigidbody>() != null)
            {
                currentActor.GetComponent<Rigidbody>().useGravity = false;
                currentActor.GetComponent<Rigidbody>().AddForce(currentActor.transform.up * gravity ,  ForceMode.Force);
            }
            
            
        }

    }
}
