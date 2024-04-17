using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedgame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed;
    }
}
