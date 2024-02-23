using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Enemymovementgoat : MonoBehaviour
{
    public Death deadCheck;
    const float k_TouchingRadius = .05f;
    private float horizontalMove = 0f;
    private bool goingRight = false;
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
                charging = false;
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
                charging = false;
                //Debug.Log("Left");
            }

        }
        RaycastHit2D RaycastLeft = Physics2D.Raycast(m_LeftCheck.transform.position, Rightdirection, 10f, m_WhatIsPlayer);
        if (RaycastLeft.rigidbody == PlayBody && charging == false && startCharging == false)
        {
            goingRight = true;
            startCharging = true;
            Debug.Log("Yes2");
        }
        RaycastHit2D RaycastRight = Physics2D.Raycast(m_RightCheck.transform.position, Leftdirection, 10f, m_WhatIsPlayer);
        if (RaycastRight.rigidbody == PlayBody && charging == false && startCharging == false)
        {
            goingRight = false;
            startCharging = true;
            Debug.Log("Yes1");
        }
        if (startCharging)
        {
            horizontalMove = 0;
            chargeTimer = chargeTimer + 1; 
        }
        if (chargeTimer == 50)
        {
            startCharging = false;
            chargeTimer = 0;
            charging = true;
        }
        if (goingRight && charging == false && startCharging == false)
        {
            horizontalMove = 3;
        }
        else if (goingRight == false && charging == false && startCharging == false)
        {
            horizontalMove = -3;
        } 
        else if (goingRight && charging)
        {
            horizontalMove = 12;
        } 
        else if (goingRight == false && charging)
        {
            horizontalMove = -12;
        }
        m_Rigidbody2D.velocity = new Vector2(horizontalMove, m_Rigidbody2D.velocity.y);

    }
}
