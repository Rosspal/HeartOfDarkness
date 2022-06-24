using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMenuPause : MonoBehaviour
{
    [SerializeField] Canvas menuPause;
    [SerializeField] Canvas settings;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSound;

    private void Start()
    {
        settings.enabled = false;   
    }

    public void OpenSettings()
    {
        GetComponent<SoundBox>().PlayClick();
        menuPause.enabled = false;
        sliderMusic.value = GetComponent<SettingsControler>().Music;
        sliderSound.value = GetComponent<SettingsControler>().Sound;
        settings.enabled = true;
    }

    public void CloseSettings()
    {
        GetComponent<SoundBox>().PlayClick();
        menuPause.enabled = true;
        settings.enabled = false;
    }
}
