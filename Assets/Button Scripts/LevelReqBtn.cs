using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementButtons : MonoBehaviour
{
    [SerializeField] public Mastercontroler mastercontroler;
    // Start is called before the first frame update
    [SerializeField] private Button btn = null;
    [SerializeField] private int VariableState;
    [SerializeField] private int requirement;
    [SerializeField] private int Level;

    private void Awake()
    {
        // adding a delegate with no parameters
        btn.onClick.AddListener(NoParamaterOnclick);

        // adding a delegate with parameters
    }
    private void Update()
    {
        if (mastercontroler.latestLevel > requirement)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
        }
    }
    private void NoParamaterOnclick()
    {
        mastercontroler.level = Level;
        mastercontroler.state = VariableState;
        mastercontroler.activateMenus = true;
    }
}
