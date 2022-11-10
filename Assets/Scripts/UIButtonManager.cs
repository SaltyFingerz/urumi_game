using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    public GameObject ControlsPrompt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public  void CloseControlsPrompt()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ControlsPrompt.SetActive(false);
        
    }
}
