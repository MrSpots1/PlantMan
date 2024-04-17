using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowersprite : MonoBehaviour
{
    [SerializeField] int FlowerCounter = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite Flower1;
    public Sprite Flower2;
    public Sprite Flower3;
    int FlowerStep = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = Flower1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FlowerCounter = FlowerCounter + 1;
        if (FlowerCounter == 25)
        {
            FlowerCounter = 0;
            if (FlowerStep == 1)
            {
                FlowerStep = 2;
                spriteRenderer.sprite = Flower1;
            }
            else if (FlowerStep == 2)
            {
                FlowerStep = 3;
                spriteRenderer.sprite = Flower2;
            }
            else if (FlowerStep == 3)
            {
                FlowerStep = 1;
                spriteRenderer.sprite = Flower3;
            }

        }
    }
}
