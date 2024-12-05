using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class Level2Manager : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public TextMeshProUGUI health;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI puzzleText;

    public GameObject defaultPlayer;
    public GameObject DeathScreen;
    public GameObject Gem;
    public GameObject puzzle;

    public Vector3 playerPos;

    public static bool isDone = false;
    public static bool isKey = false;
    public int numPuzzle = 1;
    int currentPuzzle = 1;

    PlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        if (CharacterSelection.currentPlayer != null)
        {
            defaultPlayer = CharacterSelection.currentPlayer;
        }

        DeathScreen.SetActive(false);

        PlayerPrefs.SetInt("Shield", 0);

        spawnPlayer();

        puzzleText.text = $"Puzzle: {currentPuzzle}/{numPuzzle}";

    }

    // Update is called once per frame
    void Update()
    {
        if (isDone)
        {
            Gem.SetActive(true);

            puzzle.SetActive(false);

            PlayerPrefs.SetInt("Shield", 1);
        }

        if (isKey)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

        if (playerHealth > playerControl.maxHealth)
        {
            playerControl.maxHealth = playerHealth;
        }

        if(playerMana > playerControl.maxMana)
        {
            playerControl.maxMana = playerMana;
        }
        

        playerControl.changeHealth((playerHealth - playerControl.health));
        playerControl.changeMana((playerMana - playerControl.mana));
        playerControl.lives = playerLives;

        

        virtualCamera.Follow = player.transform;
    }
}
