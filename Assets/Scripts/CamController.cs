using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    //this scrpit is used to move the main camera according to the movement of the mouse, for the first person controller. It also is used to move a second camera for drawing the strike path using a trail emittor and for detecting the direciton of attacks in the DirectionDetection script.

    public static float sensX = 1000;
    public static float sensY = 1000;

    public Transform orientation;
    public Transform cameraPos;


    //the rotation values used by the main camera - the rendering camera
    public static float xRotation;
    public static float yRotation;


    //the rotation values used by the second camera - used to directing the movement of the strike path
    public static float xRotation2;
    public static float yRotation2;



    void Start()
    {
       
        yRotation2 = yRotation; //initialise both cameras to point at the same point
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.position;

        //get mouse input:
        //for the rendering camera, sensitivity is a variable to be changed to zero in DirectoinDetection script while the mouse button is down:
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        //for the secondary camera used for strike:
        float mouseX2 = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 1000;
        float mouseY2 = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 1000;

        //the rotation value for moving the cameras changes incrementatically with the movement of the mouse over time:
        //main camera:
        yRotation += mouseX;
        xRotation -= mouseY;
        //camera 2:
        yRotation2 += mouseX2;
        xRotation2 -= mouseY2;


        //MathF.Clamp is used to keep the rotation value within -90 and 90,  to prevent the payer from looking up or down more than 90 degrees from the baseline
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        //set the orientation of the main camera according to the rotation values produced in each frame above based on the movement of the mouse
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        
        

    }
}
