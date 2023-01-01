using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    //This script is for triggering events based on the player's progress through the level. 
    //When the enemies of each room are cleared, the gate opens to the next room & when the last room's enemies are cleared the level complete UI element is displayed.

    public GameObject Skeleton1; //the level's skeletons are refered to to track when they have been killed
    public GameObject Skeleton2;
    public GameObject Skeleton3;
    public GameObject Skeleton4;
    public GameObject Skeleton5;
    public GameObject Skeleton6;
    public GameObject Skeleton7;
    public GameObject Skeleton8;
    public GameObject Skeleton9;
    public GameObject Skeleton10;
    public GameObject LevelComplete; //UI element for level completion
    public GameObject Player; //the player to access audio clips, and use them as the audio source for audio taunts
    void Start()
    {
        Player = GameObject.Find("Player");
    }


    void Update()
    {
        
        if(CompareTag("firstGate") && (!Skeleton1.activeSelf && !Skeleton2.activeSelf))
        {
            gameObject.SetActive(false); //removed ie opens gate
            Player.GetComponent<PlayerMovement>().PatheticSound(); //audio of player character taunting

        }

        if (CompareTag("secondGate") && (!Skeleton1.activeSelf))
        {
            gameObject.SetActive(false);
          
        }

        if(CompareTag("thirdGate") && (!Skeleton1.activeSelf && !Skeleton2.activeSelf && !Skeleton3.activeSelf && !Skeleton4.activeSelf && !Skeleton5.activeSelf && !Skeleton6.activeSelf))
        {
            gameObject.SetActive(false);
            Player.GetComponent<PlayerMovement>().PatheticSound();
        }

        if(CompareTag("FinalStage") &&  (!Skeleton7.activeSelf && !Skeleton8.activeSelf && !Skeleton9.activeSelf && !Skeleton10.activeSelf))
        {
            gameObject.SetActive(false); //this is used to prevent the audioclip below from being played multiple times upon itself causing distortion.
            Player.GetComponent<PlayerMovement>().VictoryLaugh();
            LevelComplete.SetActive(true); //activates UI element
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;
        }
    }
}
