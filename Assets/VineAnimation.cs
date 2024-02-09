using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineAnimation : MonoBehaviour
{
    public PlayerMovement buttons;
    public CharacterController2D controller;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    public Sprite Vine1;
    public Sprite Vine2;
    public Sprite Vine3;
    public Sprite Vine4;
    public Sprite Nothing;
    private int VineCounter = 0;
    private int VineStep = 1;
    public bool doubleJump;
    void Start()
    {
        spriteRenderer.sprite = Nothing;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.runDoubleJumpAnimation == true) 
        {
            VineCounter = VineCounter + 1;
            if (VineStep == 1) 
            {
                transform.position = new Vector2(controller.posX - 1, controller.posY - 1);
                VineStep = 2;
                VineCounter = 0;
                spriteRenderer.sprite = Vine1;
            }
            if (VineCounter == 10)
            {
                if (VineStep == 2)
                {
                    VineStep = 3;
                    VineCounter = 0;
                    spriteRenderer.sprite = Vine2;
                } else if (VineStep == 3)
                {
                    VineStep = 4;
                    VineCounter = 0;
                    spriteRenderer.sprite = Vine3;
                } else if (VineStep == 4)
                {
                    VineStep = 5;
                    VineCounter = 0;
                    spriteRenderer.sprite = Vine4;
                } else if (VineStep == 5)
                {
                    VineStep = 6;
                    VineCounter = 0;
                    spriteRenderer.sprite = Vine3;
                } else if (VineStep == 6)
                {
                    VineStep = 7;
                    VineCounter = 0;
                    spriteRenderer.sprite = Vine2;
                } else if (VineStep == 7)
                {
                    VineStep = 8;
                    VineCounter = 0;
                    spriteRenderer.sprite = Vine1;
                } else if (VineStep == 8)
                {
                    VineStep = 1;
                    VineCounter = 0;
                    spriteRenderer.sprite = Nothing;
                    controller.runDoubleJumpAnimation = false;
                }
            }
        }
    }
}
