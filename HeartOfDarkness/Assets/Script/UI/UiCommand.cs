using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCommand : MonoBehaviour
{
    public GameObject PosOne;
    public GameObject PosTwo;//кто в отряде
    public GameObject PosThree;
    public GameObject PosFour;

    public GameObject Pos1;
    public GameObject Pos2;
    public GameObject Pos3;// скамья запасных
    public GameObject Pos4;
    public GameObject Pos5;
    public GameObject Pos6;


    private GameObject[] newHero = new GameObject[4];
    private GameObject[] stock = new GameObject[6];

    public void Display()
    {
        string[] name = GetComponent<GameControler>().TeamModelNameAll();
        GameObject hero = GetComponent<CharacterModel>().GetCharacter(name[0]);
        newHero[0] = Instantiate(hero, PosOne.transform.position, Quaternion.identity);

        hero = GetComponent<CharacterModel>().GetCharacter(name[1]);
        newHero[1] = Instantiate(hero, PosTwo.transform.position, Quaternion.identity);

        hero = GetComponent<CharacterModel>().GetCharacter(name[2]);
        newHero[2] = Instantiate(hero, PosThree.transform.position, Quaternion.identity);

        hero = GetComponent<CharacterModel>().GetCharacter(name[3]);
        newHero[3] = Instantiate(hero, PosFour.transform.position, Quaternion.identity);
    }
}
