using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.name == "Left Road")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
