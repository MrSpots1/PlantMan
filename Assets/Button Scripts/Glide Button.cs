using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlideButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public PlayerMovement moverment;
    [SerializeField] private Button btn = null;
    [SerializeField] private Image image;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private bool WhichWay;
    [SerializeField] private Image OtherOne;

    private void Awake()
    {
        // adding a delegate with no parameters
        btn.onClick.AddListener(NoParamaterOnclick);
        if (WhichWay)
        {
            image.sprite = sprite1;
            OtherOne.sprite = sprite2;
        }
        
        // adding a delegate with parameters
    }

    private void NoParamaterOnclick()
    {
        if (WhichWay)
        {
            moverment.glideSettings = false;
            image.sprite = sprite1;
            OtherOne.sprite = sprite2;
        } else if (!WhichWay)
        {
            moverment.glideSettings = true;
            image.sprite = sprite1;
            OtherOne.sprite = sprite2;
        }
       
    }
}
