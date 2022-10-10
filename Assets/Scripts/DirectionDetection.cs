using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetection : MonoBehaviour
{
   
    public static float mouseXMove;
    [SerializeField]
    public float mouseYMove;
    [SerializeField]
    private float mouseXStart;
    [SerializeField]
    private float mouseXEnd;

    public GameObject cam;
    private float xRotation;


    [SerializeField]
    float eulerAngY;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eulerAngY = cam.transform.localEulerAngles.y;

        //Vector3 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            
             mouseXStart = eulerAngY;
            // mouseYStart = mousePos.y;
            print("startX is" + mouseXStart);
        }

        if (Input.GetMouseButtonUp(0))
        {
             mouseXEnd = eulerAngY;
           // mouseYEnd = mousePos.y;
            print("endX is" + mouseXEnd);
            mouseXMove = (mouseXEnd - mouseXStart);
            // mouseYMove = mouseYEnd - mouseYStart;
            print("movement X is" + mouseXMove);

        }

        



    }
}
