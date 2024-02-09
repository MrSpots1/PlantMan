using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool _ded
    {
        get;
        set;
    }
    
    void FixedUpdate()
    {
        if (transform.position.y <= -4) {
            _ded = true;
        }
    }
    void Update()
    {
        _ded = false;
    }
}
