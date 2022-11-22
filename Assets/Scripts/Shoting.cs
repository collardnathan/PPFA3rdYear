using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    ThirdPersonCamera _refCamera;
    public GameObject combatCamera;

    [Header("Bullet Attributes")]
    public float Damages;
    public float fireRate;

    [Header("References")]
    public Transform _muzzle;
    public GameObject bullet;
    public Camera tpsCam;
    public Transform attackPoint;
    public bool allowInvoke = true;


    [Header("Bullet")]
    public float shootForce, upwardForce;
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    [SerializeField]
    public bool shooting, readyToShoot, reloading;

    int bulletsLeft, bulletsShot;
    

    private enum Bullets { Basic, Gravity }
    private Bullets currentBullet;
    private bool canSwitch = true;
    private float timerSwitch = 1f;
    public float timerOverload = 10f;

    public KeyCode switchBullet = KeyCode.Tab;

    private void Start()
    {
        _refCamera = combatCamera.GetComponent<ThirdPersonCamera>();
    }
    private void Awake()
    {
        // Check if Magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
        reloading = false;
    }

    private void Update()
    {
        
        MyInput();

        if (canSwitch == false)
        {
            CooldownSwitch();
        }

    }

    private void MyInput()
    {
        if (Input.GetKeyDown(switchBullet) && canSwitch)
        {
            if (currentBullet == Bullets.Basic)
            {
                currentBullet = Bullets.Gravity;
            }

            else
            {
                currentBullet = Bullets.Basic;
            }
            canSwitch = false;
        }

        if (allowButtonHold) shooting = Input.GetMouseButton(0);
        else shooting = Input.GetMouseButtonDown(0);

        //Reload
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            _refCamera.GetComponent<ThirdPersonCamera>().currentStyle = ThirdPersonCamera.CameraStyle.Combat;
            Reload();
            print(reloading);
        }
        //Reload when you try to fire without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
            _refCamera.GetComponent<ThirdPersonCamera>().currentStyle = ThirdPersonCamera.CameraStyle.Combat;
        }
        
        

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0 )
        {
            //Set bullets shot to 0
            bulletsShot = 0;
            Shooting();
        }
    }

    private void Shooting()
    {
        readyToShoot = false;

        // Find the hit position with a raycast
        Ray ray = tpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Check if raycast hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(tpsCam.transform.up * upwardForce, ForceMode.Impulse);


        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
    private void CooldownSwitch(bool getStarted = false)
    {
        getStarted = true;
        if (timerSwitch > 0)
        {
            timerSwitch -= (Time.deltaTime); 
        }
        else
        {
            canSwitch = true;
            timerSwitch = 1f;
            return;
        }
    }

}
