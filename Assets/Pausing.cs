using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public bool gamePaused;
public bool justPaused;
public bool justUnpaused;
    [SerializeField] public Mastercontroler mastercontroler;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mastercontroler.state == 0)
        {
            
             if (!gamePaused)
            {
                gamePaused = true;
                Time.timeScale = 0f;
                justPaused = true;
                mastercontroler.state = 2;
                mastercontroler.activateMenus = true;
            }
        }
    }
}
