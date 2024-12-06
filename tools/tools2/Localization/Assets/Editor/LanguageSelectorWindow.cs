using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LanguageSelectorWindow : EditorWindow
{
    Texture2D LanguageSectionTexture;

    Color LanguageSectionColor = Color.black;
   
    Rect LanguageSection;

    public static LocalizationData localizationData;
    Vector2 scrollPos;

    [MenuItem("Tools/Language Localization")]
    static void OpenWindow()
    {
        LanguageSelectorWindow window = (LanguageSelectorWindow)GetWindow(typeof(LanguageSelectorWindow));

        window.titleContent = new GUIContent("Localization Editor");

        window.minSize = new Vector2(600, 300);

        window.Show();
    }

    private void OnEnable()
    {
        InitTextures();
        InitLanguages();
    }

    void InitLanguages()
    {
        localizationData = AssetDatabase.LoadAssetAtPath<LocalizationData>("Assets/Resources/Languages/Translations.asset");
    }

    void InitTextures()
    {

        LanguageSectionTexture = new Texture2D(1, 1);
        LanguageSectionTexture.SetPixel(0, 0, LanguageSectionColor);
        LanguageSectionTexture.Apply();
    }

    private void OnGUI()
    {
        DrawLayout();
        DrawLanguage();
    }

    void DrawLayout()
    {


        LanguageSection.x = 0;
        LanguageSection.y = 0;

        LanguageSection.size = new Vector2(Screen.width, Screen.height);


        GUI.DrawTexture(LanguageSection, LanguageSectionTexture);

    }

    void DrawLanguage()
    {
        GUILayout.BeginArea(LanguageSection);

        GUILayout.Label("Translations");

        GUILayout.Space(10);

        DrawTable();

        GUILayout.EndArea();
    }

    void DrawTable()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Space(Screen.width/10f);

        DrawCell("Key", true);
        DrawCell("EN", true);
        DrawCell("FR", true);
        DrawCell("ZH", true);

        if (GUILayout.Button("Add", GUILayout.Width(150), GUILayout.Height(20)))
        {
            AddTranslationWindow.OpenWindow(localizationData);
        }

        GUILayout.Space(Screen.width / 10f);

        GUILayout.EndHorizontal();

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);


        scrollPos = GUILayout.BeginScrollView(scrollPos);

        for (int i = 0; i < localizationData.entries.Count; i++)
        {
            DrawTranslations(localizationData.entries[i], i);
        }

        GUILayout.EndScrollView();
    }

    string DrawCell(string text, bool isHeader)
    {
        GUIStyle style = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleCenter,
        };

        if (isHeader)
        {
            style = new GUIStyle(GUI.skin.textField)
            {
                alignment = TextAnchor.MiddleCenter,
                fontStyle = FontStyle.Bold,
            };

            GUILayout.Label(text, style, GUILayout.Width(150), GUILayout.Height(20));
            return null;
        }
        else
        {
            return GUILayout.TextField(text, style, GUILayout.Width(150), GUILayout.Height(20));
        }
        
    }

    void DrawTranslations(LocalizationEntry entry, int index)
    {
        GUILayout.BeginHorizontal();
        
        GUILayout.Space(Screen.width / 10f);

        entry.key = DrawCell(entry.key, false);
        entry.en = DrawCell(entry.en, false);
        entry.fr = DrawCell(entry.fr, false);
        entry.zh = DrawCell(entry.zh, false);

        
        if (GUILayout.Button("Delete", GUILayout.Width(150), GUILayout.Height(20)))
        {
            localizationData.entries.RemoveAt(index);
        }
        
        GUILayout.Space((Screen.width / 10f));

        GUILayout.EndHorizontal();
    }

}


public class AddTranslationWindow: EditorWindow
{
    static LocalizationData localizationData;
    LocalizationEntry entry;

    string dataPath = "Assets/Resources/Languages/Entries/";

    public static void OpenWindow(LocalizationData data)
    {
        AddTranslationWindow window = (AddTranslationWindow)GetWindow(typeof(AddTranslationWindow));

        window.titleContent = new GUIContent("Add Translations");

        window.minSize = new Vector2(400, 300);

        window.Show();

        localizationData = data;

        Debug.Log(localizationData.entries.Count);
    }

    private void OnEnable()
    {
        entry = new LocalizationEntry();
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Label("Key:");
        entry.key = EditorGUILayout.TextField(entry.key);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label("English:");
        entry.en = EditorGUILayout.TextField(entry.en);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label("French:");
        entry.fr = EditorGUILayout.TextField(entry.fr);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label("Chinese:");
        entry.zh = EditorGUILayout.TextField(entry.zh);

        GUILayout.EndHorizontal();

        if (entry.key == null && KeyExists(entry.key))
        {
            EditorGUILayout.HelpBox("Missing or Taken Key: [Key] must be unique and filled out", MessageType.Warning);
        }
        else if (GUILayout.Button("Save", GUILayout.Width(150), GUILayout.Height(20)))
        {
            localizationData.entries.Add(entry);
            EditorUtility.SetDirty(localizationData);
            SaveTranslation();

            Close();
        }
    }

    bool KeyExists(string key)
    {
        foreach (LocalizationEntry entry in localizationData.entries)
        {
            if (entry.key == key)
            {
                return true;
            }
        }

        return false;
    }

    void SaveTranslation()
    {
        dataPath += $"{entry.key}.asset";

        AssetDatabase.CreateAsset(entry, dataPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}