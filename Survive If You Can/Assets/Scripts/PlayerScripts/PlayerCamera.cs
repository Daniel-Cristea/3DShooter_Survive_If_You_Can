using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    public Camera camera;
    private float rotationSpeed;
    private bool canRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotationCoroutine());
        InitializeVariables();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyVerticalRotation();
        
    }


    private void InitializeVariables()
    {
        
        rotationSpeed = playerInfo.cameraRotationSpeed;
    }

    private void ApplyVerticalRotation()
    {
        float v = Input.GetAxis("Mouse Y"); // Get mouse input
        float AngX = transform.localEulerAngles.x; // Get the value of Rotation on X axis

        if (canRotate && ((v > 0 && (AngX < 280 || AngX > 295)) || (v <= 0 && (AngX > 200 || AngX < 65))))
        {
            Vector3 rotation = new Vector3(v, 0, 0);
            transform.Rotate(rotation * Time.deltaTime * rotationSpeed * (-1));
        }
    }


    IEnumerator RotationCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        canRotate = true;
    }

}
