using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    public LocalizationData localizationData;

    public static LanguageManager instance;

    public string language = "en";
    
    Dictionary<string, string> languages = new Dictionary<string, string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLanguage(string language)
    {
        language = language.ToLower();

        foreach (LocalizationEntry entry in localizationData.entries)
        {
            languages[entry.key] = language switch
            {
                "en" => entry.en,
                "fr" => entry.fr,
                "zh" => entry.zh,
                _ => entry.en,
            };
        }

        foreach (LocalizedText localText in FindObjectsOfType<LocalizedText>())
        {
            localText.updateTranslation();
        }
    }

    public string GetTranslation(string key)
    {
        if (languages != null && languages.TryGetValue(key, out var translation))
        {
            return translation;
        }

        foreach (LocalizationEntry entry in localizationData.entries)
        {
            if (entry.key == key)
            {
                return entry.en;
            }
        }

        return key;
    }

}
