using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMobementBoulder : MonoBehaviour
{
    [SerializeField] public float dir;
    // Start is called before the first frame update
    public Death deadCheck;
    [SerializeField] private float spawnX = 0f;
    [SerializeField] private float spawnY = 0f;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] public float spin;
    [SerializeField] private LayerMask m_WhatIsDeath;
    [SerializeField] private LayerMask m_WhatIsAir;
    [SerializeField] private Transform m_DeathCheck;
    [SerializeField] private float k_DeadRadius;
    [SerializeField] private float upAmount;
    [SerializeField] public float waterLevel;
    [SerializeField] private GameObject us;
    [SerializeField] public float floatThreshold = 2.0f;
    [SerializeField] public float waterDensity = 0.125f;
    private GameObject lava;
    [SerializeField] private float forceFactor;
    private Vector3 floatForce;

    
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_DeathCheck.transform.position, Vector2.up, 10f, m_WhatIsAir);

        // Check if something was hit
        
        if (deadCheck._ded)
        {
            transform.position = new Vector2(spawnX, spawnY);
        }
        m_Rigidbody2D.velocity = new Vector2(dir, m_Rigidbody2D.velocity.y);
        if (dir > 0f)
        {
            m_Rigidbody2D.angularVelocity = spin;
        }
        else if (dir < 0f)
        {
            
            m_Rigidbody2D.angularVelocity = -spin;
        }
        lava = null;
        Collider2D[] deathColliders = Physics2D.OverlapCircleAll(m_DeathCheck.position, k_DeadRadius, m_WhatIsDeath);
        waterLevel = (m_Rigidbody2D.transform.position.y - k_DeadRadius / 2 + hit.distance);
        forceFactor = 1.0f - (((m_Rigidbody2D.transform.position.y- k_DeadRadius/2) - waterLevel) / (floatThreshold));
        for (int i = 0; i < deathColliders.Length; i++)
        {
            if (deathColliders[i].gameObject != gameObject)
            {
                lava = deathColliders[i].gameObject;
                

                if (forceFactor > 0.0f)
                {
                    floatForce = -Physics.gravity * m_Rigidbody2D.mass * (forceFactor - m_Rigidbody2D.velocity.y * waterDensity);

                    m_Rigidbody2D.AddForce(floatForce);
                }
            }

        }
        if (lava != null)
        {
            us.layer = 6;
        }
        else
        {
            us.layer = 8;
        }
    }
}
