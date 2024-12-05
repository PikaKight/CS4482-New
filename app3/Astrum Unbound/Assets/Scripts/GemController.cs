using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public bool isL2 = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isL2)
        {
            LevelManager.isKey = true;
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Player" && isL2)
        {
            
            Destroy(gameObject);
            Level2Manager.isKey = true;
            Level2Manager.isDone = false;
            
        }
    }
}
