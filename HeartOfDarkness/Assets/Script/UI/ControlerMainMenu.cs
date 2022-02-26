using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerMainMenu : MonoBehaviour
{
    [SerializeField] Canvas MainMenu;
    [SerializeField] Canvas Settings;
    [SerializeField] GameObject CloseTab;
    [SerializeField] Canvas LoadScreen;


    private void Start()
    {
        Settings.enabled = false;
        CloseTab.SetActive(false);
        LoadScreen.enabled = false;
    }

    public void OpenSettings()
    {
        Settings.enabled = true;
        MainMenu.enabled = false; 
    }

    public void CloseSettings()
    {
        Settings.enabled = false;
        MainMenu.enabled = true;
    }

    public void OpenNewGame()
    {
        MainMenu.enabled = false;
        LoadScreen.enabled = true;
        SceneManager.LoadScene(1);
    }

    public void OpenLoadGame()
    {
        
    }

    public void OpenCloseGameTab()
    {
        CloseTab.SetActive(true);
    }

    public void CloseGameYes()
    {
        Application.Quit();
    }

    public void CloseGameNo()
    {
        CloseTab.SetActive(false);
    }
}
