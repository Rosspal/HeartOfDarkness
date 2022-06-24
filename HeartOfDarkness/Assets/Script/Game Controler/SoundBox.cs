using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    [SerializeField] AudioClip[] musicSource;

    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioSource click;

    private void Start()
    {
        PlayMapMusic();
    }

    public void PlayClick()
    {
        click.Play();
    }

    public void PlaySound(string name)
    {
        sound.clip = Find(name);
        sound.Play();
    }

    public void PlayMapMusic()
    {
        if (music.clip.name != "MainMenu")
        {
            int rand = Random.Range(0, 3);
            music.clip = Find("Map" + rand);
            music.Play();
        }
    }

    public void PlayTownMusic()
    {
        int rand = 0;//Random.Range(0, 1);
        music.clip = Find("Town" + rand);
        music.Play();
    }

    public void PlayBattleMusic()
    {
        int rand = Random.Range(0, 1);
        music.clip = Find("Battle" + rand);
        music.Play();
    }

    public AudioClip Find(string str)
    {
        foreach (AudioClip clip in musicSource)
        {
            if (clip.name == str)
            {
                return clip;
            }
        }
        return musicSource[0];
    }

    public void SetValumeMusic(float value)
    {
        music.volume = value;
    }

    public void SetValumeSound(float value)
    {
        sound.volume = value;
        click.volume = value;
    }
}
