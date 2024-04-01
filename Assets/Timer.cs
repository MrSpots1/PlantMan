using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public Death deadCheck;
    [SerializeField] int TimerCounter;
    [SerializeField] int TimerFinish;
    // Start is called before the first frame update
    public TMP_Text myText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimerCounter++;
        string text = TimerCounter.ToString();

        myText.text = text;
        if (TimerCounter == TimerFinish)
        {
            TimerCounter = 0;
            deadCheck._ded = true;
        }
    }
}
