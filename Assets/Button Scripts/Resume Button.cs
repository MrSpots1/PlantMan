using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Pausing pause;
    [SerializeField] private Button btn = null;
    [SerializeField] private Mastercontroler mastercontroler;

    private void Awake()
    {
        // adding a delegate with no parameters
        btn.onClick.AddListener(NoParamaterOnclick);

        // adding a delegate with parameters
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void NoParamaterOnclick()
    {
        Time.timeScale = 1f;
        pause.justPaused = false;
        pause.gamePaused = false;
        mastercontroler.state = 0;
        mastercontroler.activateMenus = true;
    }
   }
