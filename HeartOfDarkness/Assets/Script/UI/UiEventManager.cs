using UnityEngine;

public class UiEventManager : MonoBehaviour
{
    [SerializeField] Canvas Town;
    [SerializeField] Canvas BattleEvent;
    [SerializeField] Camera BattleCam;
    [SerializeField] Camera MainCam;

    [SerializeField] Canvas Menu;


    void Start()
    {
        Town.enabled = false;
        BattleEvent.enabled = false;
        BattleCam.enabled = false;
        MainCam.enabled = true;
        Menu.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.enabled = true;
            MainCam.GetComponent<MoveCamera>().useCameraMovement = false;
            MainCam.GetComponent<TileClicker>().Activ = false;
        }
    }

    public void CloseMenu()
    {
        Menu.enabled = false;
        MainCam.GetComponent<MoveCamera>().useCameraMovement = true;
        MainCam.GetComponent<TileClicker>().Activ = true;
    }

    public void OpenTown()
    {
        Town.enabled = true;
        GetComponent<ManagerUiTown>().RefreshHealingCost();
        //MainCam.GetComponent<TileClicker>().Activ = false;
    }

    public void CloseTown()
    {
        Town.enabled = false;
        //MainCam.GetComponent<TileClicker>().Activ = true;
    }

    public void OpenCemetery()
    {
        BattleEvent.enabled = true;
        MainCam.GetComponent<TileClicker>().Activ = false;
        BattleCam.enabled = true;
        GetComponent<GameControler>().BattleCemeteryStart();
    }

    public void OpenBattleEvent(string str)
    {
        
        BattleEvent.enabled = true;
        MainCam.GetComponent<TileClicker>().Activ = false;
        BattleCam.enabled = true;
        GetComponent<GameControler>().BattleStart(str);

    }

    public void CloseBattleEvent()
    {
        BattleEvent.enabled = false;
        MainCam.GetComponent<TileClicker>().Activ = true;
        BattleCam.enabled = false;

    }
}
