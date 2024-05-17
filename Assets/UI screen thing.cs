using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIscreenthing : MonoBehaviour
{
    [SerializeField] float Xchange;
    [SerializeField] float Ychange;
    public Transform objectTransform;
    // Start is called before the first frame update
    private Vector2 position1 = new Vector2((-1 * ((Screen.width) / 2)) + 210, ((Screen.height) / 2) - 10);
    void Start()
    {
       

}

    // Update is called once per frame
    void Update()
    {
         position1 = new Vector2((-1 * ((Screen.width) / 2)) + Xchange, ((Screen.height) / 2) - Ychange);
        objectTransform.localPosition = position1;
    }
}
