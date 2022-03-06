using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCamp : MonoBehaviour
{
    [SerializeField] Canvas camp;
    [SerializeField] Camera command;
    [SerializeField] Camera main;
    [SerializeField] Canvas comandUi;

    // Start is called before the first frame update
    void Start()
    {
        comandUi.enabled = false;
        command.enabled = false;
        camp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            camp.enabled = true;
        }
    }

    public void CloseCamp()
    {
        camp.enabled = false;
    }

    public void OpenCommand()
    {
        comandUi.enabled = true;
        main.enabled = false;
        command.enabled = true;
        camp.enabled = false;
        GetComponent<UiCommand>().Display();
    }

    public void CloseCommand()
    {
        comandUi.enabled = false;
        command.enabled = false;
        main.enabled = true;
        camp.enabled = true;
    }
}
