using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Image EndPlayLosing, EndPlayWinning;
    public Text ammoDisplay, magazineDisplay, typeOfBullet, reloadingDisplay, scoring;
    public RawImage basic, inversed, G0;
    public Slider Health;
    [SerializeField] GameObject player;

    private void Start()
    {
        player.GetComponent<Shoting>();
    }

    private void Update()
    {
        if (Manager._Instance.Dead == true)
        {
            EndPlayLosing.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Manager._Instance.Win == true)
        {
            EndPlayWinning.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Health.value = player.GetComponent<PlayerMovement>()._health / player.GetComponent<PlayerMovement>()._maxHealth;
        scoring.text = ("Audience Score : " + (Manager._Instance.Score));
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
