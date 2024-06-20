using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlideToggle : MonoBehaviour
{
    public string say;
    public TMP_Text myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        myText.text = say;
    }
}
