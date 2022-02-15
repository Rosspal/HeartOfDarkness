using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct character
{
    public GameObject model;
    //public
}



public class CharacterModel : MonoBehaviour
{
    [SerializeField] GameObject character1;
    [SerializeField] GameObject character2;
    [SerializeField] GameObject character3;
    [SerializeField] GameObject character4;
    [SerializeField] GameObject character5;

    private List<GameObject> characterList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        characterList.Add(character1);
        characterList.Add(character2);
        characterList.Add(character3);
        characterList.Add(character4);
        characterList.Add(character5);
    }

    public int Count()
    {
        return characterList.Count;
    }

    public GameObject GetCharacterRandom(string title)
    {
        List<int> id = new List<int>();

        for (int i = 0; i != characterList.Count; i++ )
        {
            string name = characterList[i].name;
            name = name.Remove(name.Length - 1);

            if (name == title)
            {
                id.Add(i);
            }
        }
        int rand = Random.Range(0, id.Count);

        return characterList[id[rand]];
    }
}
