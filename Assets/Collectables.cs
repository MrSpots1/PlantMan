using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] public int world;
    [SerializeField] private int gravTimer = 0;
    const float k_TouchingRadius = 0.5f;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private LayerMask m_WhatIsPlayer;
    [SerializeField] private Transform Check;
    [SerializeField] private GameObject ME;
    public Mastercontroler mastercontroler;
    float y0;
    float amplitude = 0.5f;
    int speed = 2;
    public string collectableState;
    public SpriteRenderer spriteRenderer2;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.gravityScale = 0.3f;
        float thing = m_Rigidbody2D.transform.position.y;
        y0 = thing;
        collectableState = "Uncollected";
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frames
    void FixedUpdate()
    {
        if (collectableState == "Uncollected")
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(Check.position, k_TouchingRadius, m_WhatIsPlayer);

            for (int i = 0; i < colliders.Length; i++)
            {

                if (colliders[i].gameObject != gameObject)
                {
                    collectableState = "Stasis";


                    spriteRenderer2.enabled = false;
                }
            }
        }
        if (mastercontroler.leaveLevel && collectableState == "Stasis")
        {
            collectableState = "Uncollected";
        }
        if (collectableState == "Stasis" && mastercontroler.beatLevel)
        {
            if (world == 1)
            {
                mastercontroler.world1Collectable = true;
            }
            else if (world == 2)
            {
                mastercontroler.world2Collectable = true;
            }
            else if (world == 3)
            {
                mastercontroler.world3Collectable = true;
            }
            else if (world == 4)
            {
                mastercontroler.world4Collectable = true;
            }
            else if (world == 5)
            {
                mastercontroler.world5Collectable = true;
            }
            else if (world == 6)
            {
                mastercontroler.world6Collectable = true;
            }
            else if (world == 7)
            {
                mastercontroler.world7Collectable = true;
            }
            else if (world == 8)
            {
                mastercontroler.world8Collectable = true;
            }
            else if (world == 9)
            {
                mastercontroler.bonus1Collectable = true;
            }
            else if (world == 10)
            {
                mastercontroler.bonus2Collectable = true;
            }
            else if (world == 11)
            {
                mastercontroler.bonus3Collectable = true;
            }
            else if (world == 12)
            {
                mastercontroler.bonus4Collectable = true;
            }
            collectableState = "Collected";
            mastercontroler.totalCollectables++;
        }
        m_Rigidbody2D.transform.position = new Vector2(m_Rigidbody2D.transform.position.x, y0 + amplitude * Mathf.Sin(speed * Time.time));


    }
}
