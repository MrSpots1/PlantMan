using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Mastercontroler : MonoBehaviour
{
    [SerializeField] public int state = 1;
    [SerializeField] public int level = 1;
    [SerializeField] public int world = 1;
    [SerializeField] GameObject Level1Tiles;
    [SerializeField] GameObject Level1Text;
    [SerializeField] GameObject Level1Checkpoints;
    [SerializeField] GameObject Level1Finish;
    [SerializeField] GameObject Level2Tiles;
    [SerializeField] GameObject Level2Text;
    [SerializeField] GameObject Level2Checkpoints;
    [SerializeField] GameObject Level2Finish;
    [SerializeField] GameObject Level3Tiles;
    [SerializeField] GameObject Level3Text;
    [SerializeField] GameObject Level3Checkpoints;
    [SerializeField] GameObject Level3Finish;
    [SerializeField] public bool activateLevel;
    [SerializeField] public int latestLevel;
    [SerializeField] public bool finalUnlocked;
    [SerializeField] public bool GameBeaten;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        if (state == 1)
        {
            
        }
        if (activateLevel)
        {
            activateLevel = false;
            if (level == 1)
            {
                ActivateLevel1();
                DeactivateLevel2();
                DeactivateLevel3();
            }
            if (level == 2)
            {
                ActivateLevel2();
                DeactivateLevel1();
                DeactivateLevel3();
            }
            if (level == 3)
            {
                ActivateLevel3();
                DeactivateLevel1();
                DeactivateLevel2();
            }
        }
    }
    void ActivateLevel1()
    {
        Level1Tiles.SetActive(true);
        Level1Text.SetActive(true);
        Level1Checkpoints.SetActive(true);
        Level1Finish.SetActive(true);
    }
    void DeactivateLevel1()
    {
        Level1Tiles.SetActive(false);
        Level1Text.SetActive(false);
        Level1Checkpoints.SetActive(false);
        Level1Finish.SetActive(false);
    }
    void ActivateLevel2()
    {
        Level2Tiles.SetActive(true);
        Level2Text.SetActive(true);
        Level2Checkpoints.SetActive(true);
        Level2Finish.SetActive(true);
    }
    void DeactivateLevel2()
    {
        Level2Tiles.SetActive(false);
        Level2Text.SetActive(false);
        Level2Checkpoints.SetActive(false);
        Level2Finish.SetActive(false);
    }
    void ActivateLevel3()
    {
        Level3Tiles.SetActive(true);
        Level3Text.SetActive(true);
        Level3Checkpoints.SetActive(true);
        Level3Finish.SetActive(true);
    }
    void DeactivateLevel3()
    {
        Level3Tiles.SetActive(false);
        Level3Text.SetActive(false);
        Level3Checkpoints.SetActive(false);
        Level3Finish.SetActive(false);
    }
    void ActivateTitleScreen()
    {

    }
    void DeactivateTitleScreen()
    {

    }
    void ActivatePauseMenu()
    {

    }
    void DeactivatePauseMenu()
    {

    }
    void ActivateSettings()
    {

    }
    void DeactivateSettings()
    {

    }
    void ActivateWorldMap()
    {

    }
    void DeactivateWorldMap()
    {

    }

}
