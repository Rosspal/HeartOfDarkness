using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    public GameObject PosOne;
    public GameObject PosTwo;
    public GameObject PosThree;
    public GameObject PosFour;

    private GameObject[] newHero = new GameObject[4];

    public void Display(string[] name)
    {
        GameObject hero = GetComponent<CharacterModel>().GetCharacterRandom(name[0]);
        newHero[0] = Instantiate(hero, PosOne.transform.position, Quaternion.identity);

        hero = GetComponent<CharacterModel>().GetCharacterRandom(name[1]);
        newHero[1] = Instantiate(hero, PosTwo.transform.position, Quaternion.identity);

        hero = GetComponent<CharacterModel>().GetCharacterRandom(name[2]);
        newHero[2] = Instantiate(hero, PosThree.transform.position, Quaternion.identity);

        hero = GetComponent<CharacterModel>().GetCharacterRandom(name[3]);
        newHero[3] = Instantiate(hero, PosFour.transform.position, Quaternion.identity);

    }

    public void ClearDisplay()
    {
        Destroy(newHero[0]);
        Destroy(newHero[1]);
        Destroy(newHero[2]);
        Destroy(newHero[3]);
    }
}
