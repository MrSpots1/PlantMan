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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                gamePaused=false;
                Time.timeScale = 0f;
            }
            else if (gamePaused==false)
            {
                gamePaused=true;
                Time.timeScale = 1f;
            }
        }
    }
}
