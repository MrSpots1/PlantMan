using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementLion : MonoBehaviour
{
    public Death deadCheck;
    const float k_TouchingRadius = .05f;
    private float horizontalMove = 0f;
    private bool goingRight = false;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_LeftCheck;
    [SerializeField] private Transform m_RightCheck;
    [SerializeField] private Transform m_LeftCheck1;
    [SerializeField] private Transform m_RightCheck1;
    [SerializeField] private float spawnX = 0f;
    [SerializeField] private float spawnY = 0f;
    [SerializeField] public int heath = 2;

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
                goingRight = true;
                //Debug.Log("Right");
            }

        }
        Collider2D[] collidersLeft1 = Physics2D.OverlapCircleAll(m_LeftCheck1.position, k_TouchingRadius, m_WhatIsGround);
        //Debug.Log($"collidersLeft.Length: {collidersLeft.Length}");
        for (int i = 0; i < collidersLeft1.Length; i++)
        {
            //Debug.Log($"left check: {collidersLeft[i].gameObject}");
            //Debug.Log($"gameObject {gameObject}");
            if (collidersLeft1[i].gameObject != gameObject)
            {
                goingRight = true;
                //Debug.Log("Right");
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
                goingRight = false;
                //Debug.Log("Left");
            }

        }
        Collider2D[] collidersRight1 = Physics2D.OverlapCircleAll(m_RightCheck1.position, k_TouchingRadius, m_WhatIsGround);
        //Debug.Log($"collidersRight.Length: {collidersRight.Length}");
        for (int i = 0; i < collidersRight1.Length; i++)
        {
            //Debug.Log($"right check: {collidersRight[i].gameObject}");
            //Debug.Log($"gameObject {gameObject}");
            if (collidersRight1[i].gameObject != gameObject)
            {
                goingRight = false;
                //Debug.Log("Left");
            }

        }
        if (heath == 2)
        {
            if (goingRight)
            {
                horizontalMove = 4;
            }
            else
            {
                horizontalMove = -4;
            }
            m_Rigidbody2D.velocity = new Vector2(horizontalMove, m_Rigidbody2D.velocity.y);
        }
        else if (heath == 1)
        {

            if (goingRight)
            {
                horizontalMove = 6;
            }
            else
            {
                horizontalMove = -6;
            }
            m_Rigidbody2D.velocity = new Vector2(horizontalMove, m_Rigidbody2D.velocity.y);
        }

    }
}
