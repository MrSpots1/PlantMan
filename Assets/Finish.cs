using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Death deadCheck;
    public Mastercontroler mastercontroler;
    [SerializeField] private GameObject PlayBody;
    const float k_Radius = .5f;
    [SerializeField] private Transform Center;
    [SerializeField] private LayerMask m_WhatIsPlayer;
    private Rigidbody2D m_Rigidbody2D;
    public CharacterController2D MainPlayerScript;
    [SerializeField] float posX;
    [SerializeField] float posY;
    [SerializeField] private GameObject ME;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] Check = Physics2D.OverlapCircleAll(Center.position, k_Radius, m_WhatIsPlayer);
        for (int i = 0; i < Check.Length; i++)
        {
            if (Check[i].gameObject != gameObject)
            {
                Debug.Log(Check[i].gameObject + "Colliders");
                Debug.Log(PlayBody + "Player");
                if (Check[i].gameObject == PlayBody)
                {
                    MainPlayerScript.SpawnX = posX;
                    MainPlayerScript.SpawnY = posY;
                    deadCheck._ded = true;
                    mastercontroler.state = 4;
                    mastercontroler.activateMenus = true;
                    if (mastercontroler.level == mastercontroler.latestLevel)
                    {
                        mastercontroler.level++;
                    }
                    ME.SetActive(false);
                    mastercontroler.beatLevel = true;
                }
            }

        }
    }
}
