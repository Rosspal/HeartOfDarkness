using UnityEngine;
using TMPro;

public class UiEventManager : MonoBehaviour
{
    [SerializeField] Canvas Town;
    [SerializeField] Canvas BattleEvent;
    [SerializeField] Camera BattleCam;
    [SerializeField] Camera MainCam;

    [SerializeField] Canvas Menu;
    [SerializeField] Canvas Win;
    [SerializeField] Canvas Camp;
    [SerializeField] Camera CampCam;

    private bool checkMenu = false;
    private bool checkCamp = false;


    private bool map = true;

    public bool Map { get => map; set => map = value; }
    

    void Start()
    {
        Town.enabled = false;
        BattleEvent.enabled = false;
        BattleCam.enabled = false;
        MainCam.enabled = true;
        Menu.enabled = false;
        Win.enabled = false;
        Camp.enabled = false;
        CampCam.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!checkMenu)
            {
                Menu.enabled = true;
                MainCam.GetComponent<MoveCamera>().useCameraMovement = false;
                MainCam.GetComponent<TileClicker>().Activ = false;
                checkMenu = true;
                GetComponent<GameControler>().PermissionCamp = false;
            }
            else
            {
                CloseMenu();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (!checkCamp)
            {
                if (GetComponent<GameControler>().PermissionCamp)
                {
                    MainCam.GetComponent<MoveCamera>().useCameraMovement = false;
                    MainCam.GetComponent<TileClicker>().Activ = false;
                    MainCam.enabled = false;
                    CampCam.enabled = true;
                    Camp.enabled = true;

                    GetComponent<UiCamp>().Init();
                    GetComponent<DisplayCamp>().Display();

                    checkCamp = true;

                } 
            }
            else
            {
                CloseCamp();
            }

        }
    }

    public void CloseCamp()
    {
        GetComponent<DisplayCamp>().ClearDisplay();
        GetComponent<UiCamp>().Clear();
        MainCam.enabled = true;
        CampCam.enabled = false;
        Camp.enabled = false;
        MainCam.GetComponent<MoveCamera>().useCameraMovement = true;
        MainCam.GetComponent<TileClicker>().Activ = true;
        checkCamp = false;
    }

    public void EndGame()
    {
        GetComponent<GameControler>().PermissionCamp = false;
        GetComponent<SoundBox>().PlaySound("Win");
        GetComponent<SoundBox>().PlayMapMusic();
        BattleEvent.enabled = false;
        Win.enabled = true;
        Win.transform.Find("Panel").Find("Image").Find("ScoringText").GetComponent<TextMeshProUGUI>().text = "" + GetComponent<TeamContainer>().Score;
    }

    public void SaveName(string str)
    {
        Debug.Log(str);
        GetComponent<TeamContainer>().NameUser = str;
    }

    public void GameOff()
    {
        GetComponent<SoundBox>().PlayClick();
        GetComponent<ScoringTable>().AddValue(GetComponent<TeamContainer>().NameUser, GetComponent<TeamContainer>().Score);
        GetComponent<SceneControler>().ExitMainMenu();
    }

    public void CloseBattleEvent()
    {
        GetComponent<GameControler>().PermissionCamp = true;
        GetComponent<SoundBox>().PlayMapMusic();
        BattleEvent.enabled = false;
        MainCam.GetComponent<TileClicker>().Activ = true;
        BattleCam.enabled = false;
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
        checkMenu = false;
        GetComponent<GameControler>().PermissionCamp = true;
    }

    public void OpenTown()
    {
        GetComponent<GameControler>().PermissionCamp = false;
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
        GetComponent<GameControler>().PermissionCamp = true;
        map = true;
        GetComponent<SoundBox>().PlayMapMusic();
        Town.enabled = false;
        //MainCam.GetComponent<TileClicker>().Activ = true;
    }

    public void OpenCemetery()
    {
        GetComponent<GameControler>().PermissionCamp = false;
        BattleEvent.enabled = true;
        MainCam.GetComponent<TileClicker>().Activ = false;
        BattleCam.enabled = true;
        GetComponent<GameControler>().BattleCemeteryStart();
    }

    public void OpenBattleEvent(string str)
    {
        GetComponent<GameControler>().PermissionCamp = false;
        GetComponent<SoundBox>().PlayBattleMusic();
        BattleEvent.enabled = true;
        MainCam.GetComponent<TileClicker>().Activ = false;
        BattleCam.enabled = true;
        GetComponent<GameControler>().BattleStart(str);

    }

    
}
