using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameEnd : MonoBehaviour
{
    public GameObject score;
    public TMP_Text text;


    public string username;

    public static bool isOver = false;

    void Start()
    {
        score.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerControl player = other.gameObject.GetComponent<PlayerControl>();

        Debug.Log(player);

        if (player != null) {
            isOver = true;
            Time.timeScale = 0.0f;
            score.SetActive(true);

            text.text = "Final Time: " + timer.time.ToString();
        }
        
        
    }
    
}
