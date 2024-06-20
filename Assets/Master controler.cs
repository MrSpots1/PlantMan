using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Mastercontroler : MonoBehaviour
{
    [SerializeField] public int state = 1;
    [SerializeField] public int level = 1;
    [SerializeField] public int world = 1;
    [SerializeField] GameObject Level1;
    [SerializeField] GameObject Level2;
    [SerializeField] GameObject Level3;
    [SerializeField] GameObject PauseButtons;
    [SerializeField] GameObject MapButtons;
    [SerializeField] GameObject Map1;
    [SerializeField] GameObject Map2;
    [SerializeField] GameObject MapMain;
    [SerializeField] GameObject SpecialButton1;
    [SerializeField] GameObject SpecialButton2;
    [SerializeField] GameObject MainMenuButtons;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject SettingsButtons;
    [SerializeField] GameObject ProgressStuff;
    [SerializeField] GameObject CreditsFromButton;
    [SerializeField] GameObject CreditsFromCompletion;
    [SerializeField] GameObject PlantManBird;
    [SerializeField] GameObject LevelSelect1;
    [SerializeField] GameObject LevelSelect2;
    [SerializeField] GameObject LevelSelect3;
    [SerializeField] GameObject LevelSelect4;
    [SerializeField] GameObject LevelSelect5;
    [SerializeField] GameObject LevelSelect6;
    [SerializeField] GameObject LevelSelect7;
    [SerializeField] GameObject LevelSelect8;
    [SerializeField] public bool activateLevel;
    [SerializeField] public int latestLevel;
    [SerializeField] public bool world1Collectable;
    [SerializeField] public bool world2Collectable;
    [SerializeField] public bool world3Collectable;
    [SerializeField] public bool world4Collectable;
    [SerializeField] public bool world5Collectable;
    [SerializeField] public bool world6Collectable;
    [SerializeField] public bool world7Collectable;
    [SerializeField] public bool world8Collectable;
    [SerializeField] public bool bonus1Collectable;
    [SerializeField] public bool bonus2Collectable;
    [SerializeField] public bool bonus3Collectable;
    [SerializeField] public bool bonus4Collectable;
    [SerializeField] public bool bonus1complete;
    [SerializeField] public bool bonus2complete;
    [SerializeField] public bool bonus3complete;
    [SerializeField] public bool bonus4complete;
    [SerializeField] public Pausing pause;
    public int playerHitPoints;
    public bool beatLevel;
    public bool leaveLevel;
    [SerializeField] public int percent;
    [SerializeField] public int totalCollectables;
    public bool activateMenus;
    public int mapState = 1;
    // Start is called before the first frame update
    void Start()
    {
        state = 3;
        activateMenus = true;
        Time.timeScale = 0f;
        pause.gamePaused = true;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (level > latestLevel)
        {
            latestLevel = level;
        }
        
        percent = ((latestLevel - 1)*2) + totalCollectables*2;
        if (latestLevel >= 22)
        {
            percent = percent + 10;
        }
        if (latestLevel == 25)
        {
            percent = percent + 10;
        }
        if (bonus1complete)
        {
            percent = percent + 2;
        }
        if (bonus2complete)
        {
            percent = percent + 2;
        }
        if (bonus3complete)
        {
            percent = percent + 2;
        }
        if (bonus4complete)
        {
            percent = percent + 2;
        }

        if (activateMenus)
        {
            activateMenus = false;
            if (state == 0)
            {
                DeactivatePauseMenu();
                DeactivateLevelSelect1();
                DeactivateWorldMap();
                DeactivateLevelSelect2();
                DeactivateLevelSelect3();
                DeactivateLevelSelect4();
                DeactivateLevelSelect5();
                DeactivateLevelSelect6();
                DeactivateLevelSelect7();
                DeactivateLevelSelect8();
                activateLevel = true;
            }
            else if (state == 1)
            {
                ActivateSettings();
                DeactivatePauseMenu();
                DeactivateTitleScreen();
            } else if (state == 2)
            {
                ActivatePauseMenu();
                DeactivateSettings();
            } else if (state == 3)
            {
                DeactivateSettings();
                DeactivateWorldMap();
                ActivateTitleScreen();
            } else if (state == 4)
            {
                DeactivatePauseMenu();
                DeactivateSettings();
                DeactivateTitleScreen();
                DeactivateLevelSelect1();
                DeactivateLevelSelect2();
                DeactivateLevelSelect3();
                DeactivateLevelSelect4();
                DeactivateLevelSelect5();
                DeactivateLevelSelect6();
                DeactivateLevelSelect7();
                DeactivateLevelSelect8();
                if (mapState == 1)
                {
                    ActivateWorldMap();
                }
                else if (mapState == 2)
                {
                    DeactivateWorldMap();
                }
            } else if (state == 5)
            {
                DeactivateWorldMap();
                ActivateLevelSelect1();
            }
            else if (state == 6)
            {
                DeactivateWorldMap();
                ActivateLevelSelect2();
            }
            else if (state == 7)
            {
                DeactivateWorldMap();
                ActivateLevelSelect3();
            }
            else if (state == 8)
            {
                DeactivateWorldMap();
                ActivateLevelSelect4();
            }
            else if (state == 9)
            {
                DeactivateWorldMap();
                ActivateLevelSelect5();
            }
            else if (state == 10)
            {
                DeactivateWorldMap();
                ActivateLevelSelect6();
            }
            else if (state == 11)
            {
                DeactivateWorldMap();
                ActivateLevelSelect7();
            }
            else if (state == 12)
            {
                DeactivateWorldMap();
                ActivateLevelSelect8();
            }
        }
        if (activateLevel)
        {
            beatLevel = false;
            activateLevel = false;
            if (level == 1)
            {
                ActivateLevel1();
                DeactivateLevel2();
                DeactivateLevel3();
                playerHitPoints = 5;
                Time.timeScale = 1f;
                pause.gamePaused = false;
            }
            if (level == 2)
            {
                ActivateLevel2();
                DeactivateLevel1();
                DeactivateLevel3();
                playerHitPoints = 5;
            }
            if (level == 3)
            {
                ActivateLevel3();
                DeactivateLevel1();
                DeactivateLevel2();
                playerHitPoints = 4;
            }
        }
    }
    void ActivateLevel1()
    {
        Level1.SetActive(true);
        
    }
    void DeactivateLevel1()
    {
        Level1.SetActive(false);
    }
    void ActivateLevel2()
    {
        Level2.SetActive(true);
    }
    void DeactivateLevel2()
    {
        Level2.SetActive(false);
    }
    void ActivateLevel3()
    {
        Level3.SetActive(true);
    }
    void DeactivateLevel3()
    {
        Level3.SetActive(false);
    }
    void ActivateTitleScreen()
    {
        MainMenuButtons.SetActive(true);
        titleScreen.SetActive(true);
    }
    void DeactivateTitleScreen()
    {
        MainMenuButtons.SetActive(false);
    }
    void ActivatePauseMenu()
    {
        PauseButtons.SetActive(true);
    }
    void DeactivatePauseMenu()
    {
        PauseButtons.SetActive(false);
    }
    void ActivateSettings()
    {
        SettingsButtons.SetActive(true);
    }
    void DeactivateSettings()
    {
        SettingsButtons.SetActive(false);
    }
    void ActivateWorldMap()
    {
        titleScreen.SetActive(false);
        MapMain.SetActive(true);
        if (latestLevel < 22)
        {
            Map1.SetActive(true);
            Map2.SetActive(false);
            SpecialButton1.SetActive(false);
            SpecialButton2.SetActive(false);
        } else if (latestLevel < 25)
        {
            Map2.SetActive(true);
            Map1.SetActive(false);
            SpecialButton1.SetActive(true);
            SpecialButton2.SetActive(false);
        } else
        {
            Map2.SetActive(true);
            Map1.SetActive(false);
            SpecialButton1.SetActive(true);
            SpecialButton2.SetActive(true);
        }
    }
    void DeactivateWorldMap()
    {
        Map1.SetActive(false);
        Map2.SetActive(false);
        SpecialButton1.SetActive(false);
        SpecialButton2.SetActive(false);
        MapMain.SetActive(false);
    }
    void ActivateLevelSelect1() 
    {
        titleScreen.SetActive(true);
        LevelSelect1.SetActive(true);
    }
    void DeactivateLevelSelect1()
    {
        LevelSelect1.SetActive(false);
        titleScreen.SetActive(false);
    }
    void ActivateLevelSelect2()
    {

    }
    void DeactivateLevelSelect2()
    {

    }
    void ActivateLevelSelect3()
    {

    }
    void DeactivateLevelSelect3()
    {

    }
    void ActivateLevelSelect4()
    {

    }
    void DeactivateLevelSelect4()
    {

    }
    void ActivateLevelSelect5()
    {

    }
    void DeactivateLevelSelect5()
    {

    }
    void ActivateLevelSelect6()
    {

    }
    void DeactivateLevelSelect6()
    {

    }
    void ActivateLevelSelect7()
    {

    }
    void DeactivateLevelSelect7()
    {

    }
    void ActivateLevelSelect8()
    {

    }
    void DeactivateLevelSelect8()
    {

    }
}
