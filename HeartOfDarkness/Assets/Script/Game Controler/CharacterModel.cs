using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterModel : MonoBehaviour
{

    private List<GameObject> characterList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int count = GetComponent<AllCharacter>().model.Length;
        for (int i = 0; i != count; i++)
        {
            characterList.Add(GetComponent<AllCharacter>().model[i]);// запись всех спрайтов в список
        }
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

    //вернёт индекс модели
    public int GetCharacterRandomId(string title)
    {
        List<int> id = new List<int>();

        for (int i = 0; i != characterList.Count; i++)
        {
            string name = characterList[i].name;
            name = name.Remove(name.Length - 1);

            if (name == title)
            {
                id.Add(i);
            }
        }
        int rand = Random.Range(0, id.Count);

        return rand;
    }

    public GameObject GetCharacter(string title)
    {
        int n = 0;
        for (int i = 0; i != characterList.Count; i++)
        {
            if (characterList[i].name == title)
            {
                n = i;
                break;
            }
        }

        return characterList[n];
    }
}
