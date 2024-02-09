using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpritePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int idleCounter = 0;
    int idleStep = 1;
    public float runSpeed = 40f;
    int walkStep = 1;
    int swimStep = 1;
    public SpriteRenderer spriteRenderer;
    public VineAnimation vineAnimation;
    public Sprite Idle1;
    public Sprite Idle2;
    public Sprite Idle3;
    public Sprite Walk1;
    public Sprite Walk2;
    public Sprite Walk3;
    public Sprite Swim1;
    public Sprite Swim2;
    public Sprite Swim3;
    public Sprite doubleJump;
    public Sprite GroundJump;
    public Sprite SwimJump;
    private bool inAirNoMove;
    private int inAirNoMoveCounter;
    private int SwimCounter;
    [SerializeField] private float walkXTotal;
    [SerializeField] private float swimXTotal;
    [SerializeField] private float walkXTotalStored;
    private Rigidbody2D m_Rigidbody2D;
    private float horizontalMove = 0f;
    public PlayerMovement buttons;
    public CharacterController2D controller;
    void Start()
    {
        spriteRenderer.sprite = Idle1; 
    }
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // when you're in water, increse counter, and if you are in water and not in a swiming animation, swich to one. 
        if (controller.inWater)
        {
            SwimCounter = SwimCounter + 1;
            if (spriteRenderer.sprite != SwimJump && spriteRenderer.sprite != Swim1 && spriteRenderer.sprite != Swim2 && spriteRenderer.sprite != Swim3)
            {
                spriteRenderer.sprite = Swim1;
            }
        } else
        {
            SwimCounter = 0;
        }
        // if you jump and dont move, increase no move counter
        if (inAirNoMove && controller.inWater == false)
        {
            inAirNoMoveCounter = inAirNoMoveCounter + 1;
        }
        // if the counter gets to 50, change to standing frame. 
        if (inAirNoMoveCounter == 50 && spriteRenderer.sprite == GroundJump)
        {
            spriteRenderer.sprite = Idle1;
            inAirNoMoveCounter = 0;
            inAirNoMove = false;
        } else if (inAirNoMoveCounter == 50)
        {
            inAirNoMoveCounter = 0;
            inAirNoMove = false;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        walkXTotalStored = walkXTotal;
        Debug.Log(horizontalMove);
        walkXTotal = Mathf.Abs(horizontalMove)/40 + walkXTotal;
        // if you are not moving up, down, left or right
        if (-0.1f < m_Rigidbody2D.velocity.x && m_Rigidbody2D.velocity.x < 0.1f && m_Rigidbody2D.velocity.y == 0 && controller.inWater == false)
        {
            walkXTotalStored = walkXTotal;
            // increse idle counter
            idleCounter = idleCounter + 1;
            // swich to next frame in idle animation
            if (idleCounter == 25)
            {
                walkXTotal = walkXTotalStored;
                idleCounter = 0;
                if (idleStep == 1)
                {
                    idleStep = 2;
                    spriteRenderer.sprite = Idle2;
                }
                else if (idleStep == 2)
                {
                    idleStep = 3;
                    spriteRenderer.sprite = Idle3;
                }
                else if (idleStep == 3)
                {
                    idleStep = 4;
                    spriteRenderer.sprite = Idle2;
                }
                else if (idleStep == 4)
                {
                    idleStep = 1;
                    spriteRenderer.sprite = Idle1;
                }

            }
        }
        // if you jground ump, run ground jump animation
        if (controller.runGroundJumpAnimation)
        {
            spriteRenderer.sprite = GroundJump;
            walkStep = 2;
            walkXTotal = 0;
            controller.runGroundJumpAnimation = false;
            inAirNoMove = true;
        }
        // if you duoble jump, run double jump animation
        if (controller.runDoubleJumpAnimation)
        {
            spriteRenderer.sprite = doubleJump;
            controller.runDoubleJumpAnimation = false;
            walkStep = 2;
            walkXTotal = 0;
            inAirNoMove = true;
        }
        // if you swim jump, run swim jump animation
        if (controller.runSwimJumpAnimation)
        {
            spriteRenderer.sprite = SwimJump;
            controller.runSwimJumpAnimation = false;
            swimStep = 2;
        }
        // if you walk
        if (walkXTotal > 15f && controller.inWater == false)
        {
            // go to next walking frame
            walkXTotal = 0;
            if (walkStep == 1)
            {
                walkStep = 2;
                spriteRenderer.sprite = Walk2;
            }
            else if (walkStep == 2)
            {
                walkStep = 3;
                spriteRenderer.sprite = Walk1;
            }
            else if (walkStep == 3)
            {
                walkStep = 4;
                spriteRenderer.sprite = Walk3;
            }
            else if (walkStep == 4)
            {
                walkStep = 1;
                spriteRenderer.sprite = Walk1;
            }

        }
        // if you swim
        if (SwimCounter > 15)
        {
            SwimCounter = 0;
            // go to next swiming frame
            if (swimStep == 1)
            {
                swimStep = 2;
                spriteRenderer.sprite = Swim2;
            }
            else if (swimStep == 2)
            {
                swimStep = 3;
                spriteRenderer.sprite = Swim1;
            }
            else if (swimStep == 3)
            {
                swimStep = 4;
                spriteRenderer.sprite = Swim3;
            }
            else if (swimStep == 4)
            {
                swimStep = 1;
                spriteRenderer.sprite = Swim1;
            }

        }
    }
}
