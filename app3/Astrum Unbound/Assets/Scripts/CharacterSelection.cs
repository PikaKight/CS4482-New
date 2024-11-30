using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject hero;
    public GameObject mage;

    public static GameObject currentPlayer;

    public GameObject charSelectUI;

    public void SelectHero()
    {
        currentPlayer = hero;

        SceneManager.LoadScene("Main");
    }

    public void SelectMage()
    {
        currentPlayer = mage;

        SceneManager.LoadScene("Main");
    }
}
