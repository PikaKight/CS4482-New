using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignControl : MonoBehaviour
{
    public GameObject detail;

    public bool isPuzzleRoom = false;
    public GameObject puzzle;
    
    // Start is called before the first frame update
    void Start()
    {
        detail.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detail.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detail.SetActive(false);

        if (isPuzzleRoom)
        {
            gameObject.SetActive(false);
            puzzle.GetComponent<PuzzleController>().StartSimonSays();
        }

    }
}
