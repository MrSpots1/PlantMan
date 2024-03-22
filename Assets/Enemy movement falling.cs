using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemymovementfalling : MonoBehaviour
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
    [SerializeField] private GameObject ME;
    [SerializeField] private float spawnX = 0f;
    [SerializeField] private float spawnY = 0f;
    private Vector2 Downdirection = Vector2.down;
    private bool falling = false;
    private bool startFalling;
    private int fallTimer;
    private float startX;
    private float startY;
    private bool hitGround;
    private int dieTimer;
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        startX = m_Rigidbody2D.position.x;
        startY = m_Rigidbody2D.position.y;
    }
    private void OnDisable()
    {
        UnityEngine.Debug.Log("start");
        Invoke(nameof(Restore), 5f);
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
                if (falling)
                {
                    falling = false;
                    hitGround = true;
                    dieTimer = 0;
                    m_Rigidbody2D.position = new Vector2(startX, startY);
                    UnityEngine.Debug.Log("deactivatee");
                    ME.SetActive(false);
                    
                }

            }

        }
        if (startFalling)
        {
            fallTimer++;
        }
        if (fallTimer == 60)
        {
            falling = true;
            fallTimer = 0;
            startFalling = false;
        }
        RaycastHit2D RaycastDown = Physics2D.Raycast(m_LeftCheck.transform.position, Downdirection, 100f, m_WhatIsPlayer);
        if (RaycastDown.rigidbody == PlayBody && falling == false && startFalling == false)
        {
            
            if (!falling && !startFalling)
            {
                startFalling = true;
                fallTimer = 0;
                UnityEngine.Debug.Log("seePlayer");
            }
        }
        if (falling == false)
        {
            m_Rigidbody2D.position = new Vector2(startX, startY);
            m_Rigidbody2D.velocity = new Vector2(0f, 0f);
            UnityEngine.Debug.Log("running");
        }

    }
    void Restore()
    {
        UnityEngine.Debug.Log("end");
        hitGround = false;
        m_Rigidbody2D.position = new Vector2(startX, startY);
        gameObject.layer = 12;
        ME.SetActive(true);
        gameObject.layer = 12;
        m_Rigidbody2D.position = new Vector2(startX, startY);
        gameObject.layer = 8;
        dieTimer = 0;
    }
}
