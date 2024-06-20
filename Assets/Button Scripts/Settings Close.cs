using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsClose : MonoBehaviour
{
    [SerializeField] public Mastercontroler mastercontroler;
    // Start is called before the first frame update
    [SerializeField] private Button btn = null;
    public int statesaveclose;

    private void Awake()
    {
        // adding a delegate with no parameters
        btn.onClick.AddListener(NoParamaterOnclick);

        // adding a delegate with parameters
    }

    private void NoParamaterOnclick()
    {
        mastercontroler.state = statesaveclose;
        mastercontroler.activateMenus = true;

    }
}
