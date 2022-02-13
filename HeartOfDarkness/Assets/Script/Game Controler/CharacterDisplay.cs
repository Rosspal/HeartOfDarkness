using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    public GameObject PosOne;
    public GameObject PosTwo;
    public GameObject PosThree;
    public GameObject PosFour;

    public GameObject hero;
    //private GameObject newHero;
    private GameObject[] newHero = new GameObject[4];

    private void Start()
    {
        newHero[0] = Instantiate(hero, PosOne.transform.position, Quaternion.identity);
        newHero[0].GetComponent<Animator>().Play("Death");

        newHero[1] = Instantiate(hero, PosTwo.transform.position, Quaternion.identity);
        newHero[1].GetComponent<Animator>().Play("Attack1");

        newHero[2] = Instantiate(hero, PosThree.transform.position, Quaternion.identity);
        newHero[2].GetComponent<Animator>().Play("Attack2");

        newHero[3] = Instantiate(hero, PosFour.transform.position, Quaternion.identity);
        newHero[3].GetComponent<Animator>().Play("Attack3");
    }
}
