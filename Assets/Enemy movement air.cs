using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovementair : MonoBehaviour
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
    [SerializeField] private float spawnX = 0f;
    [SerializeField] private float spawnY = 0f;
    private float startingY;
    private float yVelocity;
    int x = 1;
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        startingY = m_Rigidbody2D.position.y;
        m_Rigidbody2D.gravityScale = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (deadCheck._ded)
        {
            transform.position = new Vector2(spawnX, spawnY);
            
        }
        //Debug.Log($"m_LeftCheck.position: {m_LeftCheck.position}");
        

        //Debug.Log($"m_RightCheck.position: {m_RightCheck.position}");
        Collider2D[] collidersRight = Physics2D.OverlapCircleAll(m_RightCheck.position, k_TouchingRadius, m_WhatIsGround);
        //Debug.Log($"collidersRight.Length: {collidersRight.Length}");
        for (int i = 0; i < collidersRight.Length; i++)
        {
            //Debug.Log($"right check: {collidersRight[i].gameObject}");
            //Debug.Log($"gameObject {gameObject}");
            if (collidersRight[i].gameObject != gameObject)
            {
               
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                //Debug.Log("Left");
                x = x * -1;

            }

        }
        
        horizontalMove = 5*x;
        
        yVelocity = m_Rigidbody2D.velocity.y;
        if (m_Rigidbody2D.position.y <= startingY)
        {
            yVelocity = 8f;
        }
        m_Rigidbody2D.velocity = new Vector2(horizontalMove, yVelocity);

    }
}
