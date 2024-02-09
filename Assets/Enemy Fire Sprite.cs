using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireSprite : MonoBehaviour
{
    [SerializeField] int flameCounter = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite Fire1;
    public Sprite Fire2;
    public Sprite Fire3;
    public Sprite Fire4;
    int flameStep = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = Fire1;
    }

    // Update is called once per frame
    void Update()
    {
        flameCounter = flameCounter + 1;
        if (flameCounter == 25)
        {
            flameCounter = 0;
            if (flameStep == 1)
            {
                flameStep = 2;
                spriteRenderer.sprite = Fire1;
            }
            else if (flameStep == 2)
            {
                flameStep = 3;
                spriteRenderer.sprite = Fire2;
            }
            else if (flameStep == 3)
            {
                flameStep = 4;
                spriteRenderer.sprite = Fire3;
            }
            else if (flameStep == 4)
            {
                flameStep = 1;
                spriteRenderer.sprite = Fire4;
            }

        }
    }
}
