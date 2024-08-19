using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heathbar : MonoBehaviour
{

    
    public Transform objectTransform;
    
    public float Step;
    
    [SerializeField] public float Xchange;
    [SerializeField] public float Xchange2;
    
    [SerializeField] float Ychange;
    private Vector2 position1 = new Vector2(0, 0);
    private Vector2 position2 = new Vector2(0 , 0);
    private void Update()
    {
        // Make sure the slider value is clamped between 0 and 1
        position1 = new Vector2((-1 * ((Screen.width) / 2)) + Xchange, ((Screen.height) / 2) - Ychange);
        position2 = new Vector2((-1 * ((Screen.width) / 2)) + Xchange2, ((Screen.height) / 2) - Ychange);
        UpdatePosition(Step);
        
}

    public void UpdatePosition(float value)
    {
        Vector2 newPosition = Vector2.Lerp(position2, position1, value);
        newPosition = new Vector2 (newPosition.x, newPosition.y);
        objectTransform.localPosition = newPosition;
        
        
    }

}
