using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{

    protected GameManager(){}
    
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private Player player;
    private GameObject topRoad;
    private float distance = 1.75f;

    public bool gameCanStart;

    [SerializeField] private GameObject background2;
    [SerializeField] private GameObject background3;
    private GameObject lastBackground;

    private bool ekledi;


    void Start()
    {
        ekledi = false;
        gameCanStart = false;
        Movement.Instance.jumpVelocity = 0f;
        //5 tane yol oluştur
        GenerateFirstLevel();

    }
    
    void Update()
    {
        //5 yol sonrası kamera her yükseldiğinde teker teker yol oluştur
        if (player.passedToAboveRoad)
        {
            CreateNewRoad();
        }

        if (gameCanStart)
        {

            Movement.Instance.jumpVelocity = 7f;
            gameCanStart = false;

        }
        
        CreateNewBackground();
        
        
        
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
        GameObject background2 = Instantiate(this.background2, Vector3.up * 10, Quaternion.identity);
        lastBackground = background2;
        
        roadPrefab.transform.position = Vector3.zero;
    }

    private void CreateNewRoad()
    {
        float randomX = Random.Range(-0.75f, 0.75f);
        
        Vector3 spawnPosition = new Vector3(randomX,topRoad.transform.position.y + distance,0);

        GameObject newRoad = Instantiate(roadPrefab, spawnPosition, Quaternion.identity);

        topRoad = newRoad;

    }

    private void CreateNewBackground()
    {
        

        if (Player.Instance.passCount % 5 == 0 && Player.Instance.passCount != 0 && !ekledi)
        {

            if (lastBackground.name.Contains("bg2"))
            {
                GameObject newBackground = Instantiate(background3, lastBackground.transform.position + Vector3.up * 10, Quaternion.identity);
                lastBackground = newBackground;
            }else if (lastBackground.name.Contains("bg3"))
            {
                GameObject newBackground = Instantiate(background2, lastBackground.transform.position + Vector3.up * 10, Quaternion.identity);
                lastBackground = newBackground;
            }

            ekledi = true;
        }
        else if(Player.Instance.passCount % 5 != 0)
        {
            ekledi = false;
        }
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        UIManager.Instance.OpenGameOverMenu();

    }
    
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
