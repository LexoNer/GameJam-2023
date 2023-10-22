using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenusButtons : MonoBehaviour
{
    public GameObject exitConfirmMenu;
    private bool exitConfirm;

    public void Start()
    {     
        exitConfirm = false;
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        Escape();
        SubMenuQuit();
    }

    private void SubMenuQuit()
    {
        if(exitConfirm)
        {
            exitConfirmMenu.gameObject.SetActive(true);
        }
        else
        {
            exitConfirmMenu.gameObject.SetActive(false);
        }
    }

    public void ExitCancelButton()
    {
        exitConfirm = false;
    }

    public void CreditsSceneButton()
    {
        SceneManager.LoadScene(2);
    }


    public void ActivateQuitButton()
    {
        exitConfirm = true;
    }


    public void QuitMenuButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
                                               Application.Quit();
        #endif
    }
    void Escape()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           if(exitConfirm)
            {
                exitConfirm = false;
            }
            else
            {
                exitConfirm = true;
            }
        }
    }
}
