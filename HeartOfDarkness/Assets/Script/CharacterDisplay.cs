using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    public GameObject test;
    public GameObject hero;
    private GameObject newHero;

    private void Start()
    {
        newHero = Instantiate(hero, test.transform.position, Quaternion.identity);
        newHero.GetComponent<Animator>().Play("Death");
    }
}
