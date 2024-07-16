using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class ProgressandCreditsText : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text myText;
    public Mastercontroler mastercontroler;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string text = "Credits: \nProject Manager / Lead: Taylan Derstadt\n\nProgrammer: Taylan Derstadt\n\nArtists: Taylan Derstadt (Player Art), Sienna Kim, and Kaili Tang.\n\nSound Designers: Taylan Derstadt (SFX), Otis Kelso Heggem (Music)\n\nGame Designers: Taylan Derstadt, Tristan Roath, Sienna Kim, and Otis Kelso Heggem. \n\nLevel Disigners: Taylan Derstadt, Tristan Roath, Sienna Kim, and Otis Kelso Heggem.\n\nProgress: " + mastercontroler.percent.ToString() + "%";
        myText.text = text;
    }
}
