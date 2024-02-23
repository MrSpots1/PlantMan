using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public CharacterController2D movement;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private GameObject ME;
    [SerializeField] private GameObject THEM;
    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ME + "Me");
        Debug.Log(movement.DeathObject + "later game obj");
        if (movement.DeathObject == ME)
        {
            Destroy(THEM, 0f);
        }
    }
}
