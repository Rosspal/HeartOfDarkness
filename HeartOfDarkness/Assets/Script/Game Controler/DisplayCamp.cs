using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCamp : MonoBehaviour
{
    [Header("Дружественные позиции")]
    public GameObject PosOne;
    public GameObject PosTwo;
    public GameObject PosThree;
    public GameObject PosFour;

    [SerializeField] GameObject[] card;


    private GameObject[] newHero = new GameObject[4];

    private void Start()
    {
        newHero[0] = PosOne;
        newHero[1] = PosTwo;
        newHero[2] = PosThree;
        newHero[3] = PosFour;

        for (int i = 0; i < 4; i++)
        {
            card[i].SetActive(false);
        }
    }

    public void Display()
    {
        string[] name = GetComponent<GameControler>().FriendModelNameAll();

        for (int i = 0; i < name.Length; i++)
        {
            card[i].SetActive(true);
        }

        GameObject hero = GetComponent<CharacterModel>().GetCharacter(name[0]);
        newHero[0] = Instantiate(hero, PosOne.transform.position, Quaternion.identity);
        switch (name.Length)
        {
            case 2:
                hero = GetComponent<CharacterModel>().GetCharacter(name[1]);
                newHero[1] = Instantiate(hero, PosTwo.transform.position, Quaternion.identity);
                break;
            case 3:
                hero = GetComponent<CharacterModel>().GetCharacter(name[1]);
                newHero[1] = Instantiate(hero, PosTwo.transform.position, Quaternion.identity);

                hero = GetComponent<CharacterModel>().GetCharacter(name[2]);
                newHero[2] = Instantiate(hero, PosThree.transform.position, Quaternion.identity);
                break;
            case 4:
                hero = GetComponent<CharacterModel>().GetCharacter(name[1]);
                newHero[1] = Instantiate(hero, PosTwo.transform.position, Quaternion.identity);

                hero = GetComponent<CharacterModel>().GetCharacter(name[2]);
                newHero[2] = Instantiate(hero, PosThree.transform.position, Quaternion.identity);

                hero = GetComponent<CharacterModel>().GetCharacter(name[3]);
                newHero[3] = Instantiate(hero, PosFour.transform.position, Quaternion.identity);
                break;
        }
    }

    public void ClearDisplay()
    {
        for (int i = 0; i < GetComponent<TeamContainer>().Friend.Count(); i++)
        {
            Destroy(newHero[i]);
        }

        for (int i = 0; i < GetComponent<TeamContainer>().Evil.Count(); i++)
        {
            Destroy(newHero[i + 4]);
        }

        for (int i = 0; i < 4; i++)
        {
            card[i].SetActive(false);
        }
    }

    public void ClearDisplay(int number)
    {
        Destroy(newHero[number]);
    }
}
