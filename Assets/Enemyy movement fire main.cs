using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemyymovementfiremain : MonoBehaviour
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
    [SerializeField] private Transform m_LeftCheckSpread;
    [SerializeField] private Transform m_RightCheckSpread;
    [SerializeField] private Transform Spreader;
    [SerializeField] private float spawnX = 0f;
    [SerializeField] private float spawnY = 0f;
    [SerializeField] int Timer;
    [SerializeField] int clonesMade;
    Vector3 Pos;
    int go;
    float addLeft;
    float addRight;
    string dir = "left";

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
        Collider2D[] collidersLeftSpread = Physics2D.OverlapCircleAll(m_LeftCheckSpread.position, k_TouchingRadius, m_WhatIsGround);
        //Debug.Log($"collidersLeft.Length: {collidersLeft.Length}");
        for (int i = 0; i < collidersLeftSpread.Length; i++)
        {
            //Debug.Log($"left check: {collidersLeft[i].gameObject}");
            //Debug.Log($"gameObject {gameObject}");
            if (collidersLeftSpread[i].gameObject != gameObject)
            {
                
            }

        }
        Collider2D[] collidersRightSpread = Physics2D.OverlapCircleAll(m_RightCheckSpread.position, k_TouchingRadius, m_WhatIsGround);
        //Debug.Log($"collidersRight.Length: {collidersRight.Length}");
        for (int i = 0; i < collidersRightSpread.Length; i++)
        {
            //Debug.Log($"right check: {collidersRight[i].gameObject}");
            //Debug.Log($"gameObject {gameObject}");
            if (collidersRightSpread[i].gameObject != gameObject)
            {
                
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
        if (goingRight)
        {
            horizontalMove = 3;
        }
        else
        {
            horizontalMove = -3;
        }
        m_Rigidbody2D.velocity = new Vector2(horizontalMove, m_Rigidbody2D.velocity.y);
        Timer = Timer + 1;
        if (Timer == 60)
        {
            go = Random.Range(1, 6);
            Timer = 0;
        }
        if (go == 5  || Input.GetButtonDown("Q"))
        {
            if (dir == "left") 
            {
                Pos = new Vector3(m_Rigidbody2D.transform.position.x - 1.5f , m_Rigidbody2D.transform.position.y , m_Rigidbody2D.transform.position.z );
                dir = "right";
                clonesMade = clonesMade + 1;
            }
            else if (dir  == "right") 
            {
                Pos = new Vector3(m_Rigidbody2D.transform.position.x + 1.5f, m_Rigidbody2D.transform.position.y, m_Rigidbody2D.transform.position.z);
                clonesMade = clonesMade + 1;
                dir = "left";
            }

            Instantiate(Spreader, Pos, m_Rigidbody2D.transform.rotation);
            go = 0;
        }
    }
}
