using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewButton : MonoBehaviour
{
    [SerializeField] public Mastercontroler mastercontroler;
    // Start is called before the first frame update
    [SerializeField] private Button btn = null;
    [SerializeField] private int VariableState;

    private void Awake()
    {
        // adding a delegate with no parameters
        btn.onClick.AddListener(NoParamaterOnclick);

        // adding a delegate with parameters
    }

    private void NoParamaterOnclick()
    {
        mastercontroler.state = VariableState;
        mastercontroler.activateMenus = true;

    }
}
