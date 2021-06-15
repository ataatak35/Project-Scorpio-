using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]private Player playerScript;
    
    void Start()
    {
        
    }

    
    private void Update()
    {


    }

    void LateUpdate()
    {
        
        if (playerScript.passedToAboveRoad)
        {
            Vector3 desiredPosition = transform.position + new Vector3(0, 1.75f, 0);

            transform.position = desiredPosition;

            playerScript.passedToAboveRoad = false;

        }
        
    }
    
}
