using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerMainMenu : MonoBehaviour
{
    [SerializeField] Canvas MainMenu;
    [SerializeField] Canvas Settings;
    [SerializeField] GameObject CloseTab;


    private void Start()
    {
        Settings.enabled = false;
        CloseTab.SetActive(false);
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
