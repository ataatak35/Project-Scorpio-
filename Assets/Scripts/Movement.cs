using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpForce;
    private Time firstPressed; 
    private int jumpCount = 0;
    
    void Start()
    {
        horizontalSpeed = 3f;
        jumpForce = 350f;
    }

    void Update()
    {

        Jump();    
        
    }

    private void FixedUpdate()
    {
        
        //Sağa doğru sabit hızla gidiyor
        transform.Translate( Vector2.down * horizontalSpeed * Time.fixedDeltaTime);
    }

    
    void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            jumpCount++;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime,ForceMode2D.Impulse);
            
        }
        
    }
    
}
