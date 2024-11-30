using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCollectible : MonoBehaviour
{
    public int mana;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl controller = other.GetComponent<PlayerControl>();

        if (controller != null && controller.mana < controller.maxMana)
        {
            controller.changeMana(mana);
            Destroy(gameObject);
        }
    }
}

