using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{

    public bool passedToAboveRoad = false;

    void Start()
    {
    }
    
    void Update()
    {
        
        SpawnPlayer();
                
    }

    void SpawnPlayer()
    {

        if (transform.position.x > 2.6f)
        {
            transform.position = new Vector3(-2.6f, transform.position.y, transform.position.z);
        }
        
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

            passedToAboveRoad = true;
            
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
}
