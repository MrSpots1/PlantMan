using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineAnimation : MonoBehaviour
{
    
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    public Sprite Vine1;
    public Sprite Vine2;
    public Sprite Vine3;
    public Sprite Vine4;
    public Sprite Vine5;
    public Sprite Vine6;
    public Sprite Vine7;
    public Sprite Vine8;
    public Sprite Vine9;
    public Sprite Vine10;
    public Sprite Vine11;
    public Sprite Vine12;
    
    private int VineCounter = 0;
    private int VineStep = 1;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
            
            
        if (VineCounter == 10)
        {
            if (VineStep == 1) 
            {
                VineStep = 2;
                VineCounter = 0;
                spriteRenderer.sprite = Vine1;
            }
            if (VineStep == 2)
            {
                VineStep = 3;
                VineCounter = 0;
                spriteRenderer.sprite = Vine2;
            }
            else if (VineStep == 3)
            {
                VineStep = 4;
                VineCounter = 0;
                spriteRenderer.sprite = Vine3;
            }
            else if (VineStep == 4)
            {
                VineStep = 5;
                VineCounter = 0;
                spriteRenderer.sprite = Vine4;
            }
            else if (VineStep == 5)
            {
                VineStep = 6;
                VineCounter = 0;
                spriteRenderer.sprite = Vine5;
            }
            else if (VineStep == 6)
            {
                VineStep = 7;
                VineCounter = 0;
                spriteRenderer.sprite = Vine6;
            }
            else if (VineStep == 7)
            {
                VineStep = 8;
                VineCounter = 0;
                spriteRenderer.sprite = Vine7;
            }
            else if (VineStep == 8)
            {
                VineStep = 9;
                VineCounter = 0;
                spriteRenderer.sprite = Vine8;
            }
            else if (VineStep == 9)
            {
                VineStep = 10;
                VineCounter = 0;
                spriteRenderer.sprite = Vine9;
            }
            else if (VineStep == 10)
            {
                VineStep = 11;
                VineCounter = 0;
                spriteRenderer.sprite = Vine10;
            }
            else if (VineStep == 11)
            {
                VineStep = 12;
                VineCounter = 0;
                spriteRenderer.sprite = Vine11;
            }
            else if (VineStep == 12)
            {
                VineStep = 1;
                VineCounter = 0;
                spriteRenderer.sprite = Vine12;
            }
        }
    }
}
