using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathGain : MonoBehaviour
{
    [SerializeField] public int world;
    const float k_TouchingRadius = 0.5f;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private LayerMask m_WhatIsPlayer;
    [SerializeField] private Transform Check;
    [SerializeField] private GameObject ME;
    [SerializeField] public Death death;
    [SerializeField] public int add;

    float y0;
    float amplitude = 0.5f;
    int speed = 2;
    
    public SpriteRenderer spriteRenderer2;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.gravityScale = 0.3f;
        float thing = m_Rigidbody2D.transform.position.y;
        y0 = thing;
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frames
    void FixedUpdate()
    {
        
        
            Collider2D[] colliders = Physics2D.OverlapCircleAll(Check.position, k_TouchingRadius, m_WhatIsPlayer);

            for (int i = 0; i < colliders.Length; i++)
            {

                if (colliders[i].gameObject != gameObject)
                {
                    ME.SetActive(false);
                    if (death.heathPlayer <= death.heathPoints - add)
                    {
                       death.heathPlayer = death.heathPlayer + add;
                    }
                
                }
            }
        
        
        m_Rigidbody2D.transform.position = new Vector2(m_Rigidbody2D.transform.position.x, y0 + amplitude * Mathf.Sin(speed * Time.time));


    }
}
