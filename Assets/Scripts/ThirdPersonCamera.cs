using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public GameObject refPlayer;

    public float rotationspeed;
    public CinemachineFreeLook refCinemachine;
    public enum CameraStyle
    {
        Basic,
        Aiming,
        Combat
    }

    public CameraStyle currentStyle;

    public Transform combatLookAt;

    

    private void Start()
    {
        refPlayer.GetComponent<PlayerMovement>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentStyle = CameraStyle.Combat;

    }

    private void Update()
    {
        // Rotate Orientation
        Vector3 viewdir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewdir.normalized;

        // Rotate Player Object
        if (currentStyle == CameraStyle.Basic)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationspeed);
        }
        else if (currentStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
            refCinemachine.m_Lens.FieldOfView = 60;
            refPlayer.GetComponent<PlayerMovement>().moveSpeed = refPlayer.GetComponent<PlayerMovement>().walkSpeed;
        }
        else if (currentStyle == CameraStyle.Aiming)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
            refCinemachine.m_Lens.FieldOfView = 20;
            refPlayer.GetComponent<PlayerMovement>().moveSpeed = refPlayer.GetComponent<PlayerMovement>().aimingSpeed;
        }
    }

  
}
