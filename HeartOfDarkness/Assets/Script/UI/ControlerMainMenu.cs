using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ControlerMainMenu : MonoBehaviour
{
    [SerializeField] Canvas MainMenu;
    [SerializeField] Canvas Settings;
    [SerializeField] GameObject CloseTab;
    [SerializeField] Canvas LoadScreen;
    [SerializeField] Canvas About;
    [SerializeField] Canvas Scoring;

    [SerializeField] AudioSource sound;

    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSound;

    private void Start()
    {
        Settings.enabled = false;
        Scoring.enabled = false;
        CloseTab.SetActive(false);
        LoadScreen.enabled = false;
        About.enabled = false;
        GetComponent<ScoringTable>().LoadTable();
    }

    public void OpenScoring()
    {
        Scoring.enabled = true;
        MainMenu.enabled = false;
        sound.Play();
        

        for(int i = 0; i < 5; i++)
        {
            Scoring.transform.Find("MenuBackground").Find("Image" + i).Find("Text").GetComponent<TextMeshProUGUI>().text = GetComponent<ScoringTable>().RunToString(i);
        }   
    }

    public void CloseScoring()
    {
        Scoring.enabled = false;
        MainMenu.enabled = true;
        sound.Play();
    }

    public void OpenSettings()
    {
        Settings.enabled = true;
        MainMenu.enabled = false;
        sound.Play();

        sliderMusic.value = GetComponent<SettingsControler>().Music;
        sliderSound.value = GetComponent<SettingsControler>().Sound;

    }

    public void OpenAbout()
    {
        About.enabled = true;
        MainMenu.enabled = false;
        sound.Play();
    }

    public void CloseAbout()
    {
        About.enabled = false;
        MainMenu.enabled = true;
        sound.Play();
    }

    public void CloseSettings()
    {
        Settings.enabled = false;
        MainMenu.enabled = true;
        sound.Play();
    }

    public void OpenNewGame()
    {
        MainMenu.enabled = false;
        LoadScreen.enabled = true;
        sound.Play();
        SceneManager.LoadScene(1);
    }

    public void OpenLoadGame()
    {
        
    }

    public void OpenCloseGameTab()
    {
        sound.Play();
        CloseTab.SetActive(true);
    }

    public void CloseGameYes()
    {
        sound.Play();
        Application.Quit();
    }

    public void CloseGameNo()
    {
        sound.Play();
        CloseTab.SetActive(false);
    }
}
