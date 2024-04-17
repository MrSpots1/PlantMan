using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdsprite : MonoBehaviour
{
    [SerializeField] int birdCounter = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite Bird1;
    public Sprite Bird2;
    public Sprite Bird3;
    public Sprite Bird4;
    int birdStep = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = Bird1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        birdCounter = birdCounter + 1;
        if (birdCounter == 25)
        {
            birdCounter = 0;
            if (birdStep == 1)
            {
                birdStep = 2;
                spriteRenderer.sprite = Bird1;
            }
            else if (birdStep == 2)
            {
                birdStep = 3;
                spriteRenderer.sprite = Bird2;
            }
            else if (birdStep == 3)
            {
                birdStep = 4;
                spriteRenderer.sprite = Bird3;
            }
            else if (birdStep == 4)
            {
                birdStep = 1;
                spriteRenderer.sprite = Bird4;
            }

        }
    }
}
