using UnityEngine;

public class UiEventManager : MonoBehaviour
{
    [SerializeField] Canvas Town;
    [SerializeField] Canvas BattleEvent;
    [SerializeField] Camera BattleCam;
    [SerializeField] Camera MainCam;

    [SerializeField] Canvas Menu;

    private bool map = true;

    public bool Map { get => map; set => map = value; }

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

    public void Click()
    {
        if (map)
        {
            GetComponent<SoundBox>().PlayClick();
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
        MainCam.GetComponent<MoveCamera>().useCameraMovement = false;
        MainCam.GetComponent<TileClicker>().Activ = false;
        map = false;
        Town.enabled = true;
        GetComponent<SoundBox>().PlayTownMusic();
        GetComponent<ManagerUiTown>().RefreshHealingCost();
        //MainCam.GetComponent<TileClicker>().Activ = false;
    }

    public void CloseTown()
    {
        map = true;
        GetComponent<SoundBox>().PlayMapMusic();
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
        GetComponent<SoundBox>().PlayBattleMusic();
        BattleEvent.enabled = true;
        MainCam.GetComponent<TileClicker>().Activ = false;
        BattleCam.enabled = true;
        GetComponent<GameControler>().BattleStart(str);

    }

    public void CloseBattleEvent()
    {
        GetComponent<SoundBox>().PlayMapMusic();
        BattleEvent.enabled = false;
        MainCam.GetComponent<TileClicker>().Activ = true;
        BattleCam.enabled = false;
    }
}
