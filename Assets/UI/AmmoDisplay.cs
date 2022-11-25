using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public Text ammoDisplay, magazineDisplay, typeOfBullet, reloadingDisplay;
    public RawImage basic, inversed, G0;
    [SerializeField] GameObject player;


    private void Start()
    {
        player.GetComponent<Shoting>();
    }

    private void Update()
    {
        ammoDisplay.text = player.GetComponent<Shoting>().bulletsLeft.ToString();
        magazineDisplay.text = player.GetComponent<Shoting>().magazineSize.ToString();

        if (player.GetComponent<Shoting>().reloading == false)
        {
            reloadingDisplay.enabled = false;
        }

        else if (player.GetComponent<Shoting>().reloading == true)
        {
            reloadingDisplay.enabled = true;
        }

        if (player.GetComponent<Shoting>().currentBul == 0)
        {
            basic.enabled = true;
            G0.enabled = false;
            inversed.enabled = false;
            typeOfBullet.text = "Basic";
        }

        else if (player.GetComponent<Shoting>().currentBul == 1)
        {
            basic.enabled = false;
            G0.enabled = true;
            inversed.enabled = false;
            typeOfBullet.text = "G0";
        }

        else
        {
            basic.enabled = false;
            G0.enabled = false;
            inversed.enabled = true;
            typeOfBullet.text = "Inversed";
        }

    }

}
