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
    public int FielofViewAiming;
    public int FielofViewCombat;
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

        
            if (currentStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;

            if (refCinemachine.m_Lens.FieldOfView <= FielofViewCombat)
            {
                refCinemachine.m_Lens.FieldOfView = refCinemachine.m_Lens.FieldOfView + (Time.deltaTime * 2 * 100);
            }

            refPlayer.GetComponent<PlayerMovement>().moveSpeed = refPlayer.GetComponent<PlayerMovement>().walkSpeed;
        }
        else if (currentStyle == CameraStyle.Aiming)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
            if (refCinemachine.m_Lens.FieldOfView >= FielofViewAiming)
            { 
                refCinemachine.m_Lens.FieldOfView = refCinemachine.m_Lens.FieldOfView - (Time.deltaTime * 2 * 100);
                
            }
            refPlayer.GetComponent<PlayerMovement>().moveSpeed = refPlayer.GetComponent<PlayerMovement>().aimingSpeed;
        }
    }

  
}
