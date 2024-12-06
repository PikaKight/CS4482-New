using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LocalizedText : MonoBehaviour
{
    public string LocalizedKey;
    public TextMeshProUGUI uiText;
    // Start is called before the first frame update
    void Start()
    {
        updateTranslation();
    }

    public void updateTranslation()
    {
        if (uiText != null && LanguageManager.instance != null)
        {
            uiText.text = LanguageManager.instance.GetTranslation(LocalizedKey);
        }
    }
}
