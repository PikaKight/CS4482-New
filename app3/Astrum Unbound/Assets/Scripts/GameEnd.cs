using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameEnd : MonoBehaviour
{
    public TMP_Text text;


    public string username;

    public static bool isOver = false;

    void Start()
    {
        isOver = true;
        Time.timeScale = 0.0f;

        text.text = "Final Time: " + timer.time.ToString();
    }

}
