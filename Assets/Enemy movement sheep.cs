using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovementsheep : MonoBehaviour
{
    public Death deadCheck;
    const float k_TouchingRadius = .05f;
    private float horizontalMove = 0f;
    private bool goingRight = true;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private Rigidbody2D PlayBody;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private LayerMask m_WhatIsPlayer;
    [SerializeField] private Transform m_LeftCheck;
    [SerializeField] private Transform m_RightCheck;
    [SerializeField] private Transform KillCheck;
    [SerializeField] private GameObject ME;
    [SerializeField] private float spawnX = 0f;
    [SerializeField] private float spawnY = 0f;
    private Vector2 Leftdirection = Vector2.left;
    private Vector2 Rightdirection = Vector2.right;
    private bool charging;
    private bool startCharging;
    private int chargeTimer;
    int x = 1;

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
            goingRight = true;
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
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                //Debug.Log("Left");
                x = x * -1;
            }

        }
        if (x == 1)
        {
            horizontalMove = -3;
        }
        else
        {
            horizontalMove = 3;
        }
        
        
        
        m_Rigidbody2D.velocity = new Vector2(horizontalMove, m_Rigidbody2D.velocity.y);

    }
}
