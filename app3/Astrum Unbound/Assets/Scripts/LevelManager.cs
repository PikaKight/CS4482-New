using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject door;
    public GameObject spike;
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
    public static List<GameObject> enemies = new List<GameObject>();

    public CinemachineVirtualCamera virtualCamera;
    public TextMeshProUGUI health;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI enemyText;

    public GameObject instructions;
    public GameObject DeathScreen;

    PlayerControl playerControl;


    public bool isStart = true;
    public static bool isRespawn = false;
    public static bool isDead = false;
    public static bool isDone = false;
    public static bool isKey = false;


    int playerLives;
    // Start is called before the first frame update
    void Start()
    {
        if (CharacterSelection.currentPlayer != null)
        {
            defaultPlayer = CharacterSelection.currentPlayer;
        }

        DeathScreen.SetActive(false);

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

        if (isDead)
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

        if (boss.GetComponent<EnemyController>().health <= 0 && !isDone)
        {
            Instantiate(Gem, Gem.transform.position, Quaternion.identity);
        }

        if (isKey)
        {
            door.SetActive(false);
        }

        if (enemies.Count > 0)
        {

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
            GameObject enemy = Instantiate(enemy1, E1Pos[i], Quaternion.identity);

            enemies.Add(enemy);
        }

    }

    public void hideInstructions()
    {
        instructions.SetActive(false);
        isStart = false;
        Time.timeScale = 1.0f;
    }

}
