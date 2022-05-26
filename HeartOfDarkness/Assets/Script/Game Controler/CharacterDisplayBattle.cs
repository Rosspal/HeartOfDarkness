using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplayBattle : MonoBehaviour
{
    [SerializeField] GameObject posPanel;
    [Header("Дружественные позиции")]
    public GameObject PosOne;
    public GameObject PosTwo;
    public GameObject PosThree;
    public GameObject PosFour;

    [Header("Вражеские позиции")]
    public GameObject EPosOne;
    public GameObject EPosTwo;
    public GameObject EPosThree;
    public GameObject EPosFour;

    private GameObject[] newHero = new GameObject[8];

    private void Start()
    {
        newHero[0] = PosOne;
        newHero[1] = PosTwo;
        newHero[2] = PosThree;
        newHero[3] = PosFour;

        newHero[4] = EPosOne;
        newHero[5] = EPosTwo;
        newHero[6] = EPosThree;
        newHero[7] = EPosFour;
    }

    public void DeadHero(int n)
    {
        if (newHero[n].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DeathEnd"))
        {

        }
        else
        {
            newHero[n].GetComponent<Animator>().Play("Death");
        } 
    }

    public void AttackHero(int n)
    {
        newHero[n].GetComponent<Animator>().Play("Attack1");
    }

    public void Display()
    {
        string[] name = GetComponent<GameControler>().FriendModelNameAll();
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


        name = GetComponent<GameControler>().EvilModelNameAll();
        hero = GetComponent<CharacterModel>().GetCharacter(name[0]);
        newHero[4] = Instantiate(hero, EPosOne.transform.position, EPosOne.transform.rotation);
        switch (name.Length)
        {
            case 2:
                hero = GetComponent<CharacterModel>().GetCharacter(name[1]);
                newHero[5] = Instantiate(hero, EPosTwo.transform.position, EPosTwo.transform.rotation);
                break;
            case 3:
                hero = GetComponent<CharacterModel>().GetCharacter(name[1]);
                newHero[5] = Instantiate(hero, EPosTwo.transform.position, EPosTwo.transform.rotation);

                hero = GetComponent<CharacterModel>().GetCharacter(name[2]);
                newHero[6] = Instantiate(hero, EPosThree.transform.position, EPosThree.transform.rotation);
                break;
            case 4:
                hero = GetComponent<CharacterModel>().GetCharacter(name[1]);
                newHero[5] = Instantiate(hero, EPosTwo.transform.position, EPosTwo.transform.rotation);

                hero = GetComponent<CharacterModel>().GetCharacter(name[2]);
                newHero[6] = Instantiate(hero, EPosThree.transform.position, EPosThree.transform.rotation);

                hero = GetComponent<CharacterModel>().GetCharacter(name[3]);
                newHero[7] = Instantiate(hero, EPosFour.transform.position, EPosFour.transform.rotation);
                break;
        }

    }

    public void ClearDisplay()
    {
        //for (int i = 0; i != newHero.Length; i++)
        //{
        //    Destroy(newHero[i]);
        //}

        
        for (int i = 0; i < GetComponent<TeamContainer>().Friend.Count(); i++)
        {
            Destroy(newHero[i]);
        }

        for (int i = 0; i < GetComponent<TeamContainer>().Evil.Count(); i++)
        {
            Destroy(newHero[i + 4]);
        }
    }

    public void ClearDisplay(int number)
    {
        Destroy(newHero[number]);
    }
}
