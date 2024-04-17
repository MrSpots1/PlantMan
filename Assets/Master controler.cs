using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mastercontroler : MonoBehaviour
{
    [SerializeField] public int level = 1;
    
    [SerializeField] GameObject Level1Tiles;
    [SerializeField] GameObject Level1Text;
    [SerializeField] GameObject Level1Checkpoints;
    [SerializeField] GameObject Level1Finish;
    [SerializeField] GameObject Level2Tiles;
    [SerializeField] GameObject Level2Text;
    [SerializeField] GameObject Level2Checkpoints;
    [SerializeField] GameObject Level2Finish;
    [SerializeField] public bool activateLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        if (activateLevel)
        {
            activateLevel = false;
            if (level == 1)
            {
                ActivateLevel1();
                DeactivateLevel2();
            }
            if (level == 2)
            {
                ActivateLevel2();
                DeactivateLevel1();
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
    
}
