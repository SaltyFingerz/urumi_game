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
    public Text correctAttacksTute;
    public static bool tuteRight = false;
    public static bool tuteLeft = false;
    public static bool tuteCentre = false;

    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {

        


        if (SceneManager.GetActiveScene().buildIndex == 0)
        correctAttacksTute.text = DirectionDetection.correctAttacks.ToString();
        if (tuteRight && DirectionDetection.correctAttacks >= 3)
        {
            DirectionDetection.correctAttacks = 0;
            tuteRight = false;
            tuteLeft = true;
            TutePrompt2.SetActive(true);
            TutePrompt1.SetActive(false);
        }

        if (tuteLeft && DirectionDetection.correctAttacks >= 3)
        {
            DirectionDetection.correctAttacks = 0;
            TutePrompt2.SetActive(false);
            TutePrompt3.SetActive(true);
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

    public  void CloseControlsPrompt()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ControlsPrompt.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 0)
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
        DeathScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    public void Level1Button()
    {
        SceneManager.LoadScene(1);

    }
}
