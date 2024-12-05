using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI btnText;
    Color ogColor;


    public static bool isPaused = false;
    public GameObject menu;

    private void Start()
    {
        if (menu != null)
        {
            menu.SetActive(false);
        }
        

        if (btnText != null)
        {
            ogColor = btnText.color;
        }
    }

    private void Update()
    {
        if (menu != null)
        {
            if (isPaused)
            {

                menu.SetActive(true);
                Time.timeScale = 0.0f;

            }
            else if (GameEnd.isOver)
            {
                menu.SetActive(false);
                Time.timeScale = 1.0f;

            }
           
            else
            {
                menu.SetActive(false);
            }
        }
    }

    public void onHover()
    {
        if (btnText != null)
        {
            btnText.color = Color.yellow;
        }
    }

    public void resetColor()
    {
        if (btnText != null)
        {
            btnText.color = ogColor;
        }
    }

    public void onSelect()
    {
        if (btnText != null)
        {
            btnText.color = new Color(227, 210, 36);
        }
    }
    
    public void startGame()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

   public void loadLeaderboard()
   {
        SceneManager.LoadScene("Leaderboard");
   }

   public void quitGame()
   {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
   }

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void returnMenu()
    {
        Time.timeScale = 1.0f;

        timer.time = 0.0f;

        isPaused = false;

        SceneManager.LoadScene("Menu");
    }

    public static void resumeGame()
    {
        isPaused = false;

        Time.timeScale = 1.0f;

        if (LevelManager.isDead)
        {
                Time.timeScale = 1.0f;
                LevelManager.isRespawn = true;
                LevelManager.isDead = false;
        }

    }

    public static void restartGame()
    {
        timer.time = 0.0f;
        isPaused=false;

        SceneManager.LoadScene("Main");
    }

}
