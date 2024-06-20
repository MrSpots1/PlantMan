using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSettings : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Mastercontroler mastercontroler;
    [SerializeField] private Button btn = null;
    [SerializeField] public int statesave;
    [SerializeField] private SettingsClose close;

    private void Awake()
    {
        // adding a delegate with no parameters
        btn.onClick.AddListener(NoParamaterOnclick);

        // adding a delegate with parameters
    }

    private void NoParamaterOnclick()
    {
        close.statesaveclose = statesave;
        mastercontroler.state = 1;
        mastercontroler.activateMenus = true;
    }

  
    
    
}
