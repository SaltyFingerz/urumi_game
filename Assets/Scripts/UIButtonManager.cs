using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonManager : MonoBehaviour
{
    //UI Prompt Elements
    public GameObject ControlsPrompt;
    public GameObject DeathScreen;
    public GameObject TutePrompt1;
    public GameObject TutePrompt2;
    public GameObject TutePrompt3;
    public GameObject TutePrompt4;
    public GameObject WeaponSwitchPrompt;
    public GameObject Scarecrow1;
    public GameObject Scarecrow2;
    public GameObject Scarecrow3;
    public GameObject PauseMenu;

    //the number of correct attacks done, shown in the tutorial
    public Text correctAttacksTute; //sending the number of correct attacks to the UI was done following this tutorial: www.youtube.com/watch?v=ch4QCcsFQ4M&t=181s

    //Booleans describing which stage of the tutorial the player is on. These are static to be used in Direction Detection, for displaying the visual feedback of tick/cross when correct/incorrect attacks are done.
    public static bool tuteRight = false;
    public static bool tuteLeft = false;
    public static bool tuteCentre = false;

    //Boolean for detecting when the player has switched the weapon for the first time, so the prompt explaining how to switch the weapon does not get shown again.
    private bool weaponSwitched;

   
    void Update()
    {

        if(PlayerMovement.UrumiPicked && !weaponSwitched)
        {
            WeaponSwitchPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {                                                  // E changes the weapon (in DirectionDetection.cs, when the player does this the prompt explaining how to change weapon goes away via the code here
                WeaponSwitchPrompt.SetActive(false);
                weaponSwitched = true;                     //prevents the prompt for switching the weapon showing up again
            }
        }


        if (SceneManager.GetActiveScene().buildIndex == 1 && (TutePrompt1.activeSelf || TutePrompt2.activeSelf || TutePrompt3.activeSelf) && correctAttacksTute != null) //the build index checks whether the active scene is the tutorial, so only then the text of correct attacks is shown.
        correctAttacksTute.text = DirectionDetection.correctAttacks.ToString(); //the number of correct attacks done is shown as a Text UI element, after converting the number of correct attacks to string
        if (tuteRight && DirectionDetection.correctAttacks >= 3)
        {
            DirectionDetection.correctAttacks = 0;  //the number of correct attacks is reset to zero upon reaching the required amount of three.
            tuteRight = false;   //this boolean is used by the DirectionDetection Script to display the appropriate feedback of tick/cross during correct/incorrect attacks
            tuteLeft = true;
            TutePrompt2.SetActive(true); //the next prompt is activated and the preceding one deactivated
            TutePrompt1.SetActive(false);
            Scarecrow1.SetActive(false); //the scarecrow is changed to a replica with different positioning of the shields
            Scarecrow2.SetActive(true);
        }

        if (tuteLeft && DirectionDetection.correctAttacks >= 3) //the same as directtly above, for the next prompt (for teaching attacks from the left)
        {
            DirectionDetection.correctAttacks = 0;
            TutePrompt2.SetActive(false);
            TutePrompt3.SetActive(true);
            Scarecrow2.SetActive(false);
            Scarecrow3.SetActive(true);
            tuteLeft = false;
            tuteCentre = true;
        }

        if (tuteCentre && DirectionDetection.correctAttacks >= 3) //the same as directly above, for the next prompt (for teaching stab attacks)
        {
            DirectionDetection.correctAttacks = 0;
            TutePrompt3.SetActive(false);
            TutePrompt4.SetActive(true);
            
            tuteCentre = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }

    

  
    public void ResumeButton() //this is called in the pause menu
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);

    }


    public  void CloseControlsPrompt() //not currently used, but can be used for displayig the controls at the start of a level
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ControlsPrompt.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        TutePrompt1.SetActive(true);
     
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartTutorialButton() //called when the player presses Okay! in the first prompt of the tutorial that explains the movement controls
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;                     //the cursor is locked to the centre of the screen and made invsibile for the first person gameplay 
        ControlsPrompt.SetActive(false);             //the prompt is inactivated
        if (SceneManager.GetActiveScene().buildIndex == 1)  //whether the scene is the tutorial is checked, and if so the nbext prompt is activated
            TutePrompt1.SetActive(true);
        tuteRight = true;                                  //the current stage of the tutorial is saved as a public static bool for the DirectionDetection script to be able to display appropriate visual feedback with each correct/incorrect attack
        
    }

    public void StartLevel() //called when closing the mission brief displayed at the start of level one
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ControlsPrompt.SetActive(false);
    }
   

    public void Retry()                                                  //called upon pressing the retry button after dying
    {
        PlayerMovement.PlayerHealth = 50;  //resets player health
        DeathScreen.SetActive(false);      //deactivates the death screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //reloads the scene


    }
    //The following are called from the main menu upon selecting each level
    public void Level1Button()  //from main menu
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;

    }

    public void TutorialButton() //from main menu
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

 
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenuButton() //called from pause menu
    {
        SceneManager.LoadScene(0);
    }
}
