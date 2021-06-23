using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : Singleton<Movement>
{
    protected Movement(){}
    
    [SerializeField] public float horizontalSpeed;
    [SerializeField] public float jumpVelocity;
    private Player player;

    private bool isGainingSpeed;
    private bool hizlandi;
    void Start()
    {
        isGainingSpeed = false;
        hizlandi = false;
        
        horizontalSpeed = 3f;
        player = Player.Instance;

    }

    void Update()
    {

        Jump();

        if (ScoreManager.Instance.score % 100 == 0 && ScoreManager.Instance.score != 0 && !hizlandi)
            isGainingSpeed = true;
        else if (ScoreManager.Instance.score % 100 != 0)
            hizlandi = false;
        
    }

    private void FixedUpdate()
    {
        //Sağa doğru sabit hızla gidiyor
        transform.Translate( Vector2.right * horizontalSpeed * Time.fixedDeltaTime);

        if (isGainingSpeed)
        {
            horizontalSpeed += 0.2f;
            isGainingSpeed = false;
            hizlandi = true;
        }
        
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
