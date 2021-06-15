using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpVelocity;
    private Player player;
    
    void Start()
    {
        horizontalSpeed = 3f;
        jumpVelocity =7f;
        player = Player.Instance;

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
            if (player.isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            }
            else
            {
                if (player.canDoubleJump)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
                    player.canDoubleJump = false;
                }
            }
            
        }
        
    }
    
}
