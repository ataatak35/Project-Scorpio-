using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : Singleton<Player>
{
    
    protected Player(){}

    public bool passedToAboveRoad = false;
    private GameObject groundCheck;
    public bool isGrounded = true;
    public bool canDoubleJump;
    public int passCount;

    void Start()
    {
        groundCheck = transform.GetChild(0).gameObject;
        passCount = 0;
    }
    
    void Update()
    {
        
        SpawnPlayer();
        IsGrounded();

    }

    void SpawnPlayer()
    {

        if (transform.position.x > 2.6f)
            transform.position = new Vector3(-2.6f, transform.position.y, transform.position.z);
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Passing Object")
        {

            Transform parent = other.transform.parent;
            GameObject leftObstacle = parent.transform.GetChild(4).gameObject;
            GameObject rightObstacle = parent.transform.GetChild(3).gameObject;
            
            Destroy(leftObstacle);
            Destroy(rightObstacle);
            Destroy(other);

            if(passCount > 0)
                passedToAboveRoad = true;

            passCount++;
            
            ScoreManager.Instance.AddPointsToScore();
            
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.collider.name == "Left Obstacle" || other.collider.name == "Right Obstacle")
        {
           
            GameManager.Instance.GameOver();
        }
    }

    void IsGrounded()
    {
        float distance = 0.01f;
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, distance);
        
        if (hit.collider != null)
        {
            
            if (hit.collider.name == "Left Road" || hit.collider.name == "Right Road" || hit.collider.name == "Floor")
            {
                isGrounded = true;
                canDoubleJump = true;
            }
            else
            {
                isGrounded = false;
            }
            
        }
        else
        {
            isGrounded = false;
        }
        
        
    }
}
