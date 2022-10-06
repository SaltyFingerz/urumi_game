using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetection : MonoBehaviour
{
    [SerializeField]
    public static float mouseXMove;
    [SerializeField]
    public float mouseYMove;
    
    private float mouseXStart;
    private float mouseXEnd;
    private float mouseYStart;
    private float mouseYEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             mouseXStart = Input.GetAxisRaw("Mouse X") * Time.deltaTime;
             mouseYStart = Input.GetAxisRaw("Mouse Y") * Time.deltaTime;
            
        }

        if (Input.GetMouseButtonUp(0))
        {
             mouseXEnd = Input.GetAxisRaw("Mouse X") * Time.deltaTime;
             mouseYEnd = Input.GetAxisRaw("Mouse Y") * Time.deltaTime;
            
            

        }

        mouseXMove = mouseXEnd - mouseXStart;
        mouseYMove = mouseYEnd - mouseYStart;

        
        
        
    }
}
