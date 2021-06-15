using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{

    protected GameManager(){}
    
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private Player player;
    private GameObject topRoad;
    private float distance = 1.75f;
    
    void Start()
    {
        //5 tane yol oluştur
        GenerateFirstLevel();

    }
    
    void Update()
    {
        //5 yol sonrası kamera her yükseldiğinde teker teker yol oluştur
        if (player.passedToAboveRoad)
        {
            createNewRoad();
        }
    }


    void GenerateFirstLevel()
    {
        roadPrefab.transform.position += new Vector3(0,-2.65f,0);
        
        for (int i = 0; i < 5; i++)
        {
            
            float spawnPositionY = roadPrefab.transform.position.y; 
            float randomX = Random.Range(-0.75f, 0.75f);
            Vector3 position = new Vector3(randomX, spawnPositionY, roadPrefab.transform.position.z);

            GameObject cloneRoad = Instantiate(roadPrefab, position, Quaternion.identity);
            
            roadPrefab.transform.position = roadPrefab.transform.position + new Vector3(0,distance,0);

            topRoad = cloneRoad;

        }
        
        roadPrefab.transform.position = Vector3.zero;
    }

    private void createNewRoad()
    {
        float randomX = Random.Range(-0.75f, 0.75f);
        
        Vector3 spawnPosition = new Vector3(randomX,topRoad.transform.position.y + distance,0);

        GameObject newRoad = Instantiate(roadPrefab, spawnPosition, Quaternion.identity);

        topRoad = newRoad;

    }

    public void GameOver()
    {
        
    }
}
