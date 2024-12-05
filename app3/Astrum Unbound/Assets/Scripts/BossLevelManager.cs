using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class BossLevelManager : MonoBehaviour
{
    public GameObject door;

    public GameObject defaultPlayer;
    public Vector3 playerPos;

    public GameObject boss;

    public CinemachineVirtualCamera virtualCamera;
    public TextMeshProUGUI health;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI bossText;
    public TextMeshProUGUI shieldStatus;

    public GameObject DeathScreen;
    public GameObject gameOverScreen;

    PlayerControl playerControl;

    public static bool isDone = false;
    public static bool isStarted = false;

    public static bool isRespawn = false;
    public static bool isDead = false;

    bool isOver = false;


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

    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            SceneManager.LoadScene("GameEnd");
        }

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

    }

    void spawnPlayer()
    {

        GameObject player = Instantiate(defaultPlayer, playerPos, Quaternion.identity);

        playerControl = player.GetComponent<PlayerControl>();

        float playerHealth = PlayerPrefs.GetFloat("Player_Health", playerControl.health);
        float playerMana = PlayerPrefs.GetFloat("Player_Mana", playerControl.mana);
        int playerLives = PlayerPrefs.GetInt("Lives", playerControl.lives);

        playerControl.healthStatus = health;
        playerControl.manaStatus = manaText;
        playerControl.shieldStatus = shieldStatus;

        playerControl.changeHealth((playerHealth - playerControl.health));
        playerControl.changeMana((playerMana - playerControl.mana));
        playerControl.lives = playerLives;

        virtualCamera.Follow = player.transform;
    }
    void updateLives()
    {
        playerLives = playerControl.lives;
        lifeText.text = $"Lives: {playerLives}";
    }
}
