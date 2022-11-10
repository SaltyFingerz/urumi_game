using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    public GameObject ControlsPrompt;
    

    public void OnButtonCloseTutePrompt()
    {
        ControlsPrompt.SetActive(false);
    }
}
