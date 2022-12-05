using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public GameObject ControlsPrompt;
    public GameObject DeathScreen;
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

    public void Retry()
    {
        DeathScreen.SetActive(false);
        SceneManager.LoadScene(0);
     
        
    }
}
