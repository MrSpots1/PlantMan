using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingstones : MonoBehaviour
{
    public Death deadCheck;
    public CharacterController2D characterController;
    private Rigidbody2D m_Rigidbody2D;
    Collider2D[] colliders2;
    float startX;
    float startY;
    bool Touched = false;
    [SerializeField] int fallcounter = 0;
    bool fall;
    [SerializeField] int fallingcounter = 0;
    [SerializeField] private GameObject ME;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        startY = m_Rigidbody2D.position.y;
        startX = m_Rigidbody2D.position.x;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (characterController.collider1 == ME && Touched == false)
        {
            Touched = true;
        }
        if (characterController.collider2 == ME && Touched == false)
        {
            Touched = true;
        }
        if (characterController.collider3 == ME && Touched == false)
        {
            Touched = true;
        }
        if (characterController.colliderIce2 == ME && Touched == false)
        {
            Touched = true;
        }
        if (characterController.colliderIce2 == ME && Touched == false)
        {
            Touched = true;
        }
        if (characterController.colliderice == ME && Touched == false)
        {
            Touched = true;
        }
        if (Touched)
        {
            fallcounter++;
        }
        Debug.Log(m_Rigidbody2D);
        if (fallcounter == 100)
        {
            fall = true;
            fallcounter = 0;
            Touched = false;
        }
        if (fall)
        {
            fallingcounter++;
        }
        if (!fall)
        {
            m_Rigidbody2D.position = new Vector2(startX, startY);
            m_Rigidbody2D.velocity = new Vector2(0f, 0f);
        }
        if (fallingcounter == 500)
        {
            fall = false;
            fallingcounter = 0;
        }
        
    }
}
