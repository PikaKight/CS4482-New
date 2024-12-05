using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shield : MonoBehaviour
{
    public float durability = 10f;
    public TextMeshProUGUI shieldStatus;

    float currentDurability = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentDurability = durability;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDurability <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void changeDurability(float damage)
    {
        currentDurability = Mathf.Clamp(currentDurability + damage, 0, durability);
        shieldStatus.text = $"Shield: {(currentDurability/durability) * 100} %";
    }


}
