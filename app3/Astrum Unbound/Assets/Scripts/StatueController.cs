using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatueController : MonoBehaviour
{
    public bool nextStage = false;
    public float increaseHealth = 5f;
    public float increaseMana = 20f;


    public bool isPuzzleStage = false;
    public GameObject puzzle;
    public float delay = 0.2f;

    float puzzleTimer = 0;

    void Update()
    {
        puzzleTimer -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerControl player = other.gameObject.GetComponent<PlayerControl>();

        

        if (player != null && nextStage)
        {
            Debug.Log(player.health + increaseHealth);
            
            PlayerPrefs.SetFloat("Player_Health", player.health + increaseHealth);
            PlayerPrefs.SetFloat("Player_Mana", player.mana + increaseMana);
            PlayerPrefs.SetInt("Lives", player.lives);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (player != null && !nextStage && !isPuzzleStage){
            SceneManager.LoadScene("GameEnd");
        }
        else if (player != null && isPuzzleStage && puzzleTimer <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            
            PuzzleController puzzleControl = puzzle.GetComponent<PuzzleController>();

            puzzleControl.PlayerInteraction(gameObject.name);

        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isPuzzleStage)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            puzzleTimer = delay;
        }
    }
}
