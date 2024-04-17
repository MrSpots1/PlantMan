using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteSheep : MonoBehaviour
{
    [SerializeField] int sheepCounter = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite sheep1;
    public Sprite sheep2;
    public Sprite sheep3;
    public Sprite sheep4;
    public Sprite sheep5;
    public Sprite sheep6;
    int sheepStep = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = sheep1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sheepCounter = sheepCounter + 1;
        if (sheepCounter == 25)
        {
            sheepCounter = 0;
            if (sheepStep == 1)
            {
                sheepStep = 2;
                spriteRenderer.sprite = sheep1;
            }
            else if (sheepStep == 2)
            {
                sheepStep = 3;
                spriteRenderer.sprite = sheep2;
            }
            else if (sheepStep == 3)
            {
                sheepStep = 4;
                spriteRenderer.sprite = sheep3;
            }
            else if (sheepStep == 4)
            {
                sheepStep = 5;
                spriteRenderer.sprite = sheep4;
            }
            else if (sheepStep == 5)
            {
                sheepStep = 6;
                spriteRenderer.sprite = sheep5;
            }
            else if (sheepStep == 6)
            {
                sheepStep = 1;
                spriteRenderer.sprite = sheep6;
            }
        }
    }
}
