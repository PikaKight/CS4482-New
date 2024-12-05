using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject door;
    public GameObject[] spikes;
    public GameObject Gem;

    public GameObject defaultPlayer;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject boss;

    public int numE1 = 3;
    public int numE2 = 2;
    public int numE3 = 0;

    public Vector2[] E1Pos;
    public Vector2[] E2Pos;
    public Vector2[] E3Pos;

    int numEnemies;
    public static List<GameObject> enemies;

    public CinemachineVirtualCamera virtualCamera;
    public TextMeshProUGUI health;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI enemyText;
    public TextMeshProUGUI bossText;

    public GameObject instructions;
    public GameObject DeathScreen;
    public GameObject gameOverScreen;

    PlayerControl playerControl;


    public static bool isStart = true;
    public static bool isRespawn = false;
    public static bool isDead = false;
    public static bool isDone = false;
    public static bool isKey = false;
    bool isOver = false; 

    int currentEnemies;
    int playerLives;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;

        Time.timeScale = 0.0f;

        if (CharacterSelection.currentPlayer != null)
        {
            defaultPlayer = CharacterSelection.currentPlayer;
        }

        DeathScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        enemies = new List<GameObject>();

        spawnPlayer();

        playerLives = playerControl.lives;

        spawnEnemies();

        currentEnemies = enemies.Count;

        enemyText.text = $"Enemies: {currentEnemies}";

        bossText.text = $"Boss: 1";
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControl.lives < playerLives)
        {
            updateLives();
        }

        if (playerLives <= 0)
        {
            isOver = true;

            Time.timeScale = 0.0f;
            gameOverScreen.SetActive(true);
        }

        if (isDead && !isOver)
        {
            Time.timeScale = 0.0f;
            DeathScreen.SetActive(true);
        }

        if (isRespawn)
        {
            DeathScreen.SetActive(false);
            isRespawn = false;
        }

        if (enemies.Count < numEnemies)
        {
            numEnemies = enemies.Count;

            enemyText.text = $"Enemies: {numEnemies}";
        }

        if (boss == null && !isDone)
        {
            bossText.text = $"Boss: 0";

            GameObject gem = Instantiate(Gem, Gem.transform.position, Quaternion.identity);
            gem.tag = "Gem";

            isDone = true;
        }

        if (isKey)
        {
            door.SetActive(false);
        }

        if (currentEnemies <= 0)
        {
            foreach (GameObject spike in spikes)
            {
                spike.SetActive(false);
            }
           
        }

        if (currentEnemies > enemies.Count)
        {
            currentEnemies = enemies.Count;
            enemyText.text = $"Enemies: {currentEnemies}";
        }
    }

    void spawnPlayer()
    {
        PlayerPrefs.SetInt("Shield", 0);

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
            GameObject enemy = Instantiate(enemy1, E1Pos[i], Quaternion.identity);

            enemies.Add(enemy);
        }

    }

    public void hideInstructions()
    {
        Debug.Log("Start Game");
        instructions.SetActive(false);
        isStart = false;
        Time.timeScale = 1.0f;
    }

}
