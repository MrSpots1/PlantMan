using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] public Mastercontroler mastercontroler;
    // Start is called before the first frame update
    [SerializeField] private Button btn = null;
    [SerializeField] private int VariableState;
    public GameObject player;
    public Death dedCheck;
    public CharacterController2D characterController;
    public Rigidbody2D playerRigid;

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
        mastercontroler.leaveLevel = true;
        player.transform.position = new Vector2(characterController.SpawnX, characterController.SpawnY);
        playerRigid.velocity = new Vector2(0f, 0f);
    }
}
