using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heathbar : MonoBehaviour
{

    
    public Transform objectTransform;
    private Vector2 position1 = new Vector2(517.1347f, 11.20587f);
    private Vector2 position2 = new Vector2(512.1904f, 11.20587f);
    public float Step;
    public Transform camera;

    private void Update()
    {
        // Make sure the slider value is clamped between 0 and 1
        UpdatePosition(Step);
    }

    public void UpdatePosition(float value)
    {
        value = value - 0.2f;
        Vector2 newPosition = Vector2.Lerp(position2, position1, value);
        newPosition = new Vector2 (newPosition.x + (camera.transform.position.x - 528f), newPosition.y + (camera.transform.position.y - 4f));
        objectTransform.position = newPosition;
        
        
    }

}
