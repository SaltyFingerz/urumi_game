using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonManager : MonoBehaviour
{
    public GameObject ControlsPrompt;
    public GameObject DeathScreen;
    public  GameObject TutePrompt1;
    public GameObject TutePrompt2;
    public GameObject TutePrompt3;
    public GameObject TutePrompt4;
    public GameObject WeaponSwitchPrompt;
    public GameObject Scarecrow1;
    public GameObject Scarecrow2;
    public GameObject Scarecrow3;
    public GameObject PauseMenu;

    public Text correctAttacksTute;
    public static bool tuteRight = false;
    public static bool tuteLeft = false;
    public static bool tuteCentre = false;
    private bool weaponSwitched;
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerMovement.UrumiPicked && !weaponSwitched)
        {
            WeaponSwitchPrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {                                                  // E changes the weapon (in DirectionDetection.cs, when the player does this the prompt explaining how to change weapon goes away via the code here
                WeaponSwitchPrompt.SetActive(false);
                weaponSwitched = true;
            }
        }


        if (SceneManager.GetActiveScene().buildIndex == 1 && (TutePrompt1.activeSelf || TutePrompt2.activeSelf || TutePrompt3.activeSelf))
        correctAttacksTute.text = DirectionDetection.correctAttacks.ToString();
        if (tuteRight && DirectionDetection.correctAttacks >= 3)
        {
            DirectionDetection.correctAttacks = 0;
            tuteRight = false;
            tuteLeft = true;
            TutePrompt2.SetActive(true);
            TutePrompt1.SetActive(false);
            Scarecrow1.SetActive(false);
            Scarecrow2.SetActive(true);
        }

        if (tuteLeft && DirectionDetection.correctAttacks >= 3)
        {
            DirectionDetection.correctAttacks = 0;
            TutePrompt2.SetActive(false);
            TutePrompt3.SetActive(true);
            Scarecrow2.SetActive(false);
            Scarecrow3.SetActive(true);
            tuteLeft = false;
            tuteCentre = true;
        }

        if (tuteCentre && DirectionDetection.correctAttacks >= 3)
        {
            DirectionDetection.correctAttacks = 0;
            TutePrompt3.SetActive(false);
            TutePrompt4.SetActive(true);
            
            tuteCentre = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }

    

  
    public void ResumeButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);

    }


    public  void CloseControlsPrompt()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ControlsPrompt.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        TutePrompt1.SetActive(true);
     
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartTutorialButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ControlsPrompt.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 1)
            TutePrompt1.SetActive(true);
        tuteRight = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ControlsPrompt.SetActive(false);
    }
   

    public void Retry()
    {
        PlayerMovement.PlayerHealth = 50;
        DeathScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    public void Level1Button()
    {
        SceneManager.LoadScene(2);

    }

    public void TutorialButton()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelPracticeButton()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
