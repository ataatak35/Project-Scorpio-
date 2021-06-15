using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]private Player playerScript;
    private float cameraSpeed = 1.5f;
    private Vector3 desiredPosition;

    void Start()
    {
        desiredPosition = transform.position;
        
    }

    
    private void Update()
    {
        
        
    }

    void LateUpdate()
    {
        
        if (playerScript.passedToAboveRoad)
        {
           
            desiredPosition = transform.position + new Vector3(0, 1.75f, 0);
            playerScript.passedToAboveRoad = false;
            
        }
        if(transform.position.y < desiredPosition.y)
            transform.Translate(Vector2.up * cameraSpeed * Time.fixedDeltaTime);
        
    }
    
}
