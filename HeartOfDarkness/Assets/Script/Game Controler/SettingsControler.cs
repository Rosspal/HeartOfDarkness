using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsControler : MonoBehaviour
{
    private float music = 0.3f;
    private float sound = 0.4f;

    public float Music { get => music; set => music = value; }
    public float Sound { get => sound; set => sound = value; }

    private void Start()
    {
        LoadSettings();
    }

    public void SetVolumeMusic(float value)
    {
        music = value;
        GetComponent<SoundBox>().SetValumeMusic(value);
    }

    public void SetVolumeSound(float value)
    {
        sound = value;
        GetComponent<SoundBox>().SetValumeSound(value);
    }

    public void SaveSettings()
    {
        GetComponent<SoundBox>().PlayClick();
        DataSave ds = new DataSave();
        ds.music = music;
        ds.sound = sound;
        GetComponent<SaveAndLoad>().Save(ds);
    }

    public void LoadSettings()
    {
        DataSave ds = GetComponent<SaveAndLoad>().Load();

        GetComponent<SoundBox>().SetValumeMusic(ds.music);
        GetComponent<SoundBox>().SetValumeSound(ds.sound);
        music = ds.music;
        sound = ds.sound;
    }
}
