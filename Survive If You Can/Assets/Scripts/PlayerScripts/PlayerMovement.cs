using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private Rigidbody rb;
    private float slowMovementSpeed;
    private float fastMovementSpeed;
    private float cameraRotationSpeed;
    private bool canRotateCamera = false;


    
    void Start()
    {
        LockCursor();
        InitializeVariables();
        StartCoroutine(RotationCoroutine());
    }


    
    void Update()
    {
        ApplyMovement();
        ApplyRotation();
    }


    private void ApplyMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        
        float movementSpeed = GetMovementSpeed();

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    void ApplyRotation()
    {
        float h = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, h, 0);

        if (canRotateCamera) { 
        transform.Rotate(rotation * Time.deltaTime * cameraRotationSpeed);
        }   
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void InitializeVariables()
    {
        slowMovementSpeed = playerInfo.slowMovementSpeed;
        fastMovementSpeed = playerInfo.fastMovementSpeed;
        cameraRotationSpeed= playerInfo.cameraRotationSpeed;
    }

    // If the Left Shift Key is pressed, the player will move faster
    private float GetMovementSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return fastMovementSpeed;
        }
        return slowMovementSpeed;

    }

    // This feature prevents unwanted movement of the camera at the beggining of the game
    IEnumerator RotationCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        canRotateCamera = true;
    }

}
