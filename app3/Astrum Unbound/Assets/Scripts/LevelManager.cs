using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject defaultPlayer;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public int numE1 = 3;
    public int numE2 = 2;
    public int numE3 = 0;

    public Vector2[] E1Pos;
    public Vector2[] E2Pos;
    public Vector2[] E3Pos;

    int maxEnemies;
    GameObject[] enemies;

    public CinemachineVirtualCamera virtualCamera;
    public TextMeshProUGUI health;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI manaText;

    public GameObject instructions;

    PlayerControl playerControl;

    public bool isStart = true;

    int playerLives;
    // Start is called before the first frame update
    void Start()
    {
        if (CharacterSelection.currentPlayer != null)
        {
            defaultPlayer = CharacterSelection.currentPlayer;
        }

        maxEnemies = numE1 + numE2 + numE3;

        enemies = new GameObject[maxEnemies];

        spawnPlayer();

        playerLives = playerControl.lives;

        spawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            Time.timeScale = 0.0f;
        }
        
        
        if (playerControl.lives < playerLives)
        {
            updateLives();
        }
    }

    void spawnPlayer()
    {
        
        GameObject player = Instantiate(defaultPlayer, defaultPlayer.transform.position, Quaternion.identity);

        playerControl = player.GetComponent<PlayerControl>();

        playerControl.healthStatus = health;
        playerControl.manaStatus = manaText;

        virtualCamera.Follow = player.transform;
    }

    public GameObject getPlayer() { 

        return defaultPlayer;
    }

    void updateLives()
    {
        playerLives = playerControl.lives;
        lifeText.text = $"Lives: {playerLives}";
    }

    void spawnEnemies()
    {
        for (int i = 0; i < numE1; i++)
        {
            Instantiate(enemy1, E1Pos[i], Quaternion.identity);
        }
    }

    public void hideInstructions()
    {
        instructions.SetActive(false);
        isStart = false;
        Time.timeScale = 1.0f;
    }

}
