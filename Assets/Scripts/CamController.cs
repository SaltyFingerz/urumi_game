using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public static float sensX = 1000;
    public static float sensY = 1000;

    public Transform orientation;
    public Transform cameraPos;

    public static float xRotation;
    public static float yRotation;

    public static float xRotation2;
    public static float yRotation2;




    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.position;

        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        float mouseX2 = Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        float mouseY2 = Input.GetAxisRaw("Mouse Y") * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        yRotation2 += mouseX2;
        xRotation2 -= mouseY2;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        
        

    }
}
