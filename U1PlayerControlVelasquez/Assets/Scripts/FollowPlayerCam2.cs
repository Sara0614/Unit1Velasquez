using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayerCam2 : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;
    public Camera driverCamera;

    // Boolean to track which camera is active
    private bool isMainView = true;

    // Offsets for different camera views
    private Vector3 offsetMain = new Vector3(0, 5, -8);
    private Vector3 offsetDriver = new Vector3(0, 2, 0);


    private void Start()
    {
        // Set the default active camera (Main Camera)
        mainCamera.enabled = true;
        driverCamera.enabled = false;
    }

    void LateUpdate()
    {
        // Switch camera when 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            isMainView = !isMainView;
            switchCamera();
        }

        // Update the camera positions based on the player's position
        mainCamera.transform.position = player.transform.position + offsetMain;
        driverCamera.transform.position = player.transform.position + offsetDriver;

        // Rotate the driver camera to match the player's rotation
        driverCamera.transform.rotation = player.transform.rotation;

        // I couldn't find a way to correctly change the main camera's rotation.When the car reaches the end and turns around, the camera does not rotate in the right direction.//
    }

    void switchCamera()
    {
        // Toggle between cameras based on isMainView variable
        if (isMainView)
        {
            mainCamera.enabled = false;
            driverCamera.enabled = true;
        }
        else
        {
            driverCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}

