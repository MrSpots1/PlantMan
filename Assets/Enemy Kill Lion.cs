using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyKillLion : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D movement;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private GameObject ME;
    [SerializeField] private GameObject THEM;
    [SerializeField] private EnemyMovementLion enemy;
    private bool noHit;
    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ME + "Me");
        //Debug.Log(movement.DeathObject + "later game obj");
        if (movement.DeathObject == ME && !movement.killerObject == THEM && movement.veloY < 0 && noHit == false)
        {
            if (enemy.heath == 2)
            {
                enemy.heath = 1;
                noHit = true;
                Invoke(nameof(Timer), 0.05f);
                
            }
            else if (enemy.heath == 1)
            {
                THEM.SetActive(false);
            }
        }
    }
    void Timer()
    {
        movement.m_Rigidbody2D.velocity = new Vector2(movement.m_Rigidbody2D.velocity.x, 12f);
        noHit = false;
        
    }
}
