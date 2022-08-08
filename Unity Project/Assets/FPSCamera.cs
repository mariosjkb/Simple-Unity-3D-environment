using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    private float horizontalSpeed = 1f;
    private float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private float MovementSpeed = 1;
    private float speed = 300;
    CharacterController characterController;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))// if W is pressed move forward
        {
            transform.position = new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))// if S is pressed move backwards
        {
            transform.position = new Vector3(0, -speed * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))// if A is pressed move to the left
        {
            transform.position = new Vector3(-speed * Time.deltaTime, 0,0);
        }
        if (Input.GetKeyDown(KeyCode.D)) // if D is pressed move to the right
        {
            transform.position = new Vector3(speed * Time.deltaTime, 0, 0);
        }
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed; // get mouse coords for x-axis
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;// get mouse coords for y-axis

        // add them to the current Rotation values
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -180, 180); 

        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);// enter the new rotation vector to the camera

        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((Vector3.right * horizontal + Vector3.forward * vertical) * Time.deltaTime);
    }
}
