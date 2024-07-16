using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Mastercontroler mastercontroler;
    
    public bool _ded
    {
        get;
        set;
    }
    [SerializeField] public int heathPlayer;

    [SerializeField] public bool hit;
    
    [SerializeField] public int heathPoints;

    [SerializeField] public bool resetPlayer;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private float gradient;
    [SerializeField] private heathbar heathbar;

    public int InvinciblityTimer;
    void FixedUpdate()
    {
        heathPoints = mastercontroler.playerHitPoints;
        if (transform.position.y <= -4) {
            _ded = true;
        }
        if (hit && InvinciblityTimer == 0)
        {
            heathPlayer = heathPlayer - 1;
            InvinciblityTimer = 40;
            hit = false;

        }
        else if (hit)
        {
            hit = false;
        }
        if (heathPlayer == 0)
        {
            _ded = true;
        }
        
        if (InvinciblityTimer > 0)
        {
            InvinciblityTimer--;
        }
        if (InvinciblityTimer > 20)
        {
            gradient = 1f - (40f - InvinciblityTimer) / 40f;
        }
        else if (InvinciblityTimer > 0)
        {
            gradient = 0.5f + (20f - InvinciblityTimer)/ 40f;
        }
        if (InvinciblityTimer > 0)
        {
            SpriteRenderer.color = new Color(1f, 1f, 1f, gradient);
        }
        
        if (InvinciblityTimer == 0)
        {
            SpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }    
        if (heathPoints == 5)
        {
            if (heathPlayer == 5)
            {
                heathbar.Step = 1f;
            }
            else if (heathPlayer == 4)
            {
                heathbar.Step = 0.8f;
            }
            else if (heathPlayer == 3)
            {
                heathbar.Step = 0.6f;
            }
            else if (heathPlayer == 2)
            {
                heathbar.Step = 0.4f;
            }
            else if (heathPlayer == 1)
            {
                heathbar.Step = 0.2f;
            }
        }
        if (heathPlayer == 0)
        {
            heathbar.Step = 0;
        }


    }
    void Update()
    {
        if (mastercontroler.leaveLevel)
        {
            _ded = true;
        }
        if (_ded)
        {
            mastercontroler.activateLevel = true;
            hit = false;
            heathPlayer = heathPoints;
            InvinciblityTimer = 0;
            resetPlayer = true;
            
        }
        _ded = false; // you died
        
    }
}
