using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineEnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Death deadCheck;
    const float k_TouchingRadius = .05f;
    [SerializeField] float BigRadius;
    private float horizontalMove = 0f;
    private bool goingRight = false;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private LayerMask m_WhatIsPlayer;
    [SerializeField] private Transform m_LeftCheck;
    [SerializeField] private Transform m_RightCheck;
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private float spawnX = 0f;
    [SerializeField] private float spawnY = 0f;
    [SerializeField] private float speed = 3;
    [SerializeField] private bool playerFocus;
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (deadCheck._ded)
        {
            transform.position = new Vector2(spawnX, spawnY);
            goingRight = false;
        }
        //Debug.Log($"m_LeftCheck.position: {m_LeftCheck.position}");
        Collider2D[] collidersLeft = Physics2D.OverlapCircleAll(m_LeftCheck.position, k_TouchingRadius, m_WhatIsGround);
        //Debug.Log($"collidersLeft.Length: {collidersLeft.Length}");
        for (int i = 0; i < collidersLeft.Length; i++)
        {
            //Debug.Log($"left check: {collidersLeft[i].gameObject}");
            //Debug.Log($"gameObject {gameObject}");
            if (collidersLeft[i].gameObject != gameObject)
            {
                if (!playerFocus)
                {
                    goingRight = true;
                }
                //Debug.Log("Right");\
                
            }

        }

        //Debug.Log($"m_RightCheck.position: {m_RightCheck.position}");
        Collider2D[] collidersRight = Physics2D.OverlapCircleAll(m_RightCheck.position, k_TouchingRadius, m_WhatIsGround);
        //Debug.Log($"collidersRight.Length: {collidersRight.Length}");
        for (int i = 0; i < collidersRight.Length; i++)
        {
            //Debug.Log($"right check: {collidersRight[i].gameObject}");
            //Debug.Log($"gameObject {gameObject}");
            if (collidersRight[i].gameObject != gameObject)
            {
                if (!playerFocus)
                {
                    goingRight = false;
                }
                //Debug.Log("Left");
                
            }

        }
        playerFocus = false;
        Collider2D[] collidersCenter = null;
        
        collidersCenter = Physics2D.OverlapCircleAll(m_Rigidbody2D.transform.position, BigRadius, m_WhatIsPlayer);
        
        //Debug.Log($"collidersRight.Length: {collidersRight.Length}");
        for (int i = 0; i < collidersCenter.Length; i++)
        {
            //Debug.Log($"right check: {collidersRight[i].gameObject}");
            //Debug.Log($"gameObject {gameObject}");
            if (collidersCenter[i].gameObject != gameObject)
            {
                playerFocus = true;
               if (collidersCenter[i].transform.position.x - m_Rigidbody2D.transform.position.x > -0.1 && collidersCenter[i].transform.position.x - m_Rigidbody2D.transform.position.x < 0.1)
                {
                    
                    goingRight =true;
                    speed = 0;
                    

                }
               else if (collidersCenter[i].transform.position.x - m_Rigidbody2D.transform.position.x > 0)
                {
                    speed = 4;
                }
               else
                {
                    goingRight = false;
                    speed = 4;
                    
                }
            }

        }
        if (collidersCenter.Length == 0)
        {
            speed = 2;
        }
        if (goingRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = -speed;
        }
        m_Rigidbody2D.velocity = new Vector2(horizontalMove, m_Rigidbody2D.velocity.y);
        if (m_Rigidbody2D.velocity.x > 0)
        {
            m_SpriteRenderer.flipX = true;
        }
        if (m_Rigidbody2D.velocity.x < 0)
        {
            m_SpriteRenderer.flipX=false;
        }

    }
    
}
