using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

public class EnemyDesignerWindow : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D warriorSectionTexture;
    Texture2D rogueSectionTexture;

    Color headerSectionColor = new Color(13f/255f, 32f/255f, 44f/255f, 1f);
    Color mageSectionColor = new Color (75f/255f, 136f/255f, 162f/255f, 1f);
    Color rougeSectionColor = new Color (162f/255f, 62f/255f, 72f/255f, 1f);
    Color warriorSectionColor = new Color (212f/255f, 160f/255f, 23f/255f, 1f);

    Rect headerSection;
    Rect rogueSection;
    Rect mageSection;
    Rect warriorSection;

    GUISkin skin;

    static MageData mageData;
    static WarriorData warriorData;
    static RogueData rogueData;

    public static MageData MageInfo { get { return mageData;} }
    public static WarriorData WarriorInfo { get { return warriorData;} }
    public static RogueData RogueInfo { get { return rogueData;} }


    [MenuItem("Window/Emeny Designer")]
    static void OpenWindow()
    {
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));

        window.minSize = new Vector2(600, 300);
        
        window.Show();
    }


    private void OnEnable()
    {
        InitTextures();
        InitData();
        skin = Resources.Load<GUISkin>("guiStyles/EnemyDesignerSkin");
    }

    public static void InitData()
    {
        mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        warriorData = (WarriorData)ScriptableObject.CreateInstance(typeof(WarriorData));
        rogueData = (RogueData)ScriptableObject.CreateInstance(typeof(RogueData));
    }


    void InitTextures()
    {
        headerSectionTexture = new Texture2D(1,1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        mageSectionTexture = new Texture2D (1,1);
        mageSectionTexture.SetPixel(0, 0, mageSectionColor);
        mageSectionTexture.Apply();

        warriorSectionTexture = new Texture2D (1,1);
        warriorSectionTexture.SetPixel(0, 0, warriorSectionColor);
        warriorSectionTexture.Apply();

        rogueSectionTexture = new Texture2D (1,1);
        rogueSectionTexture.SetPixel(0, 0, rougeSectionColor);
        rogueSectionTexture.Apply();

    }

    private void OnGUI()
    {
        DrawLayout();
        DrawHeader();
        DrawMageSettings();
        DrawWarriorSettings();
        DrawRougeSettings();

        GUI.skin = skin;
    }

    void DrawLayout()
    {
        headerSection.x = 0;
        headerSection.y = 0;

        headerSection.size = new Vector2(Screen.width, 50);

        mageSection.x = 0;
        mageSection.y = 50;

        mageSection.size = new Vector2(Screen.width/3f, Screen.height - 50);

        warriorSection.x = Screen.width/3f;
        warriorSection.y = 50;

        warriorSection.size = new Vector2(Screen.width/3f, Screen.height - 50);

        rogueSection.x = (Screen.width/3f) * 2f;
        rogueSection.y = 50;

        rogueSection.size = new Vector2(Screen.width/3f, Screen.height - 50);

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Enemy Designer", GUI.skin.GetStyle("Label"));

        GUILayout.EndArea();
    }

    void DrawMageSettings()
    {
        GUILayout.BeginArea(mageSection);

        GUILayout.Label("Mage");

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Damage Type:");
        mageData.DmgType = (MageDmgType) EditorGUILayout.EnumPopup(mageData.DmgType);

        GUILayout.EndHorizontal();

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Weapon Type:");
        mageData.WpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.WpnType);

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }

        GUILayout.EndArea();
    }

    void DrawRougeSettings()
    {
       GUILayout.BeginArea(rogueSection);

        GUILayout.Label("Rogue");

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Strategy Type:");
        rogueData.strategyType = (RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.strategyType);

        GUILayout.EndHorizontal();

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Weapon Type:");
        rogueData.wpnType = (RogueWpnType)EditorGUILayout.EnumPopup(rogueData.wpnType);

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.ROGUE);
        }

        GUILayout.EndArea();
    }

    void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);

        GUILayout.Label("Warrior");

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Class Type:");
        warriorData.WarriorClassType = (WarriorClassType)EditorGUILayout.EnumPopup(warriorData.WarriorClassType);

        GUILayout.EndHorizontal();
        
        GUILayout.Space(5);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Weapon Type:");
        warriorData.WarriorWpnType = (WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.WarriorWpnType);

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.WARRIOR);
        }

        GUILayout.EndArea();
    }



    public class GeneralSettings : EditorWindow
    {
        public enum SettingsType
        {
            MAGE,
            WARRIOR,
            ROGUE
        }

        static SettingsType dataSettings;
        static GeneralSettings window;

        public static void OpenWindow(SettingsType settings)
        {
            dataSettings = settings;
            window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
            window.minSize = new Vector2(250, 200);
            window.Show();
        }

        private void OnGUI()
        {
            switch (dataSettings)
            {
                case SettingsType.MAGE:
                    DrawSettings((CharacterData)EnemyDesignerWindow.MageInfo);
                    break;

                case SettingsType.WARRIOR:
                    DrawSettings((CharacterData)EnemyDesignerWindow.WarriorInfo);
                    break;

                case SettingsType.ROGUE:
                    DrawSettings((CharacterData)EnemyDesignerWindow.RogueInfo);
                    break;

                default:
                    return;
            }
        }

        void DrawSettings(CharacterData characterData)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label("Character Prefab");

            characterData.prefab = (GameObject)EditorGUILayout.ObjectField(characterData.prefab, typeof(GameObject), false);

            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Max Health");

            characterData.maxHealth = EditorGUILayout.FloatField(characterData.maxHealth);

            GUILayout.EndHorizontal();

            GUILayout.Space(5);

            GUILayout.BeginHorizontal();

            GUILayout.Label("Max Energy");

            characterData.maxEnergy = EditorGUILayout.FloatField(characterData.maxEnergy);
            GUILayout.EndHorizontal();

            GUILayout.Space(5);

            GUILayout.BeginHorizontal();

            GUILayout.Label("Power");

            characterData.power = EditorGUILayout.Slider(characterData.power, 0, 100);

            GUILayout.EndHorizontal();

            GUILayout.Space(5);

            GUILayout.BeginHorizontal();

            GUILayout.Label("% Crit Chance");

            characterData.critChance = EditorGUILayout.Slider(characterData.critChance, 0, characterData.power);

            GUILayout.EndHorizontal();

            GUILayout.Space(5);

            GUILayout.BeginHorizontal();

            GUILayout.Label("Character Name");

            characterData.characterName = EditorGUILayout.TextField(characterData.characterName);



            GUILayout.EndHorizontal();

            if (characterData.prefab == null)
            {
                EditorGUILayout.HelpBox("Missing Enemy Prefab: Please add a [Prefab]", MessageType.Warning);
            }
            else if (characterData.characterName == null || characterData.characterName.Length < 3)
            {
                EditorGUILayout.HelpBox("Invalid Enemy Name: Please add a " +
                    "[Character Name] that is longer than 3 character",
                    MessageType.Warning);
            }
            else if (GUILayout.Button("Save", GUILayout.Height(40)))
            {
                SaveCharacterData();
                window.Close();
            }
        }

        private void SaveCharacterData()
        {
            string newPrefabPath = "Assets/Prefabs/Characters/";
            string dataPath = "Assets/Resources/CharacterData/data/";
            string characterName = string.Empty;

            switch (dataSettings)
            {
                case SettingsType.MAGE:
                    characterName = EnsureUniqueName(EnemyDesignerWindow.MageInfo.characterName, "Mage", dataPath);
                    EnemyDesignerWindow.MageInfo.characterName = characterName;
                    EnemyDesignerWindow.MageInfo.name = characterName;

                    newPrefabPath += $"Mage/{characterName}.prefab";
                    dataPath += $"Mage/{characterName}.asset";

                    SaveAssetAndPrefab(EnemyDesignerWindow.MageInfo, newPrefabPath, dataPath, typeof(Mage));
                    break;

                case SettingsType.ROGUE:
                    characterName = EnsureUniqueName(EnemyDesignerWindow.RogueInfo.characterName, "Rogue", dataPath);
                    EnemyDesignerWindow.RogueInfo.characterName = characterName;
                    EnemyDesignerWindow.RogueInfo.name = characterName;

                    newPrefabPath += $"Rogue/{characterName}.prefab";
                    dataPath += $"Rogue/{characterName}.asset";

                    SaveAssetAndPrefab(EnemyDesignerWindow.RogueInfo, newPrefabPath, dataPath, typeof(Rogue));
                    break;

                case SettingsType.WARRIOR:
                    characterName = EnsureUniqueName(EnemyDesignerWindow.WarriorInfo.characterName, "Warrior", dataPath);
                    EnemyDesignerWindow.WarriorInfo.characterName = characterName;
                    EnemyDesignerWindow.WarriorInfo.name = characterName;

                    newPrefabPath += $"Warrior/{characterName}.prefab";
                    dataPath += $"Warrior/{characterName}.asset";

                    SaveAssetAndPrefab(EnemyDesignerWindow.WarriorInfo, newPrefabPath, dataPath, typeof(Warrior));
                    break;

                default:
                    return;
            }

            ClearWindowData();
        }

        string EnsureUniqueName(string baseName, string category, string dataPath)
        {
            int suffix = 1;
            string testName = baseName;

            while (PrefabExists(testName, $"{dataPath}{category}") > 0)
            {
                testName = $"{baseName} ({suffix++})";
            }

            return testName;
        }

        void SaveAssetAndPrefab(CharacterData characterData, string newPrefabPath, string dataPath, System.Type componentType)
        {
            // Update the internal name to match the file name
            string assetName = System.IO.Path.GetFileNameWithoutExtension(dataPath);
            characterData.name = assetName; // Ensure the name matches the asset path

            // Duplicate the ScriptableObject to avoid conflicts
            CharacterData tempData = ScriptableObject.Instantiate(characterData);

            // Create the asset
            AssetDatabase.CreateAsset(tempData, dataPath);

            // Copy and set up the prefab
            string prefabPath = AssetDatabase.GetAssetPath(tempData.prefab);
            AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            // Load and configure the prefab
            GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
            if (!prefab.GetComponent(componentType))
            {
                prefab.AddComponent(componentType);
            }

            // Link the component to the data
            if (componentType == typeof(Mage))
            {
                prefab.GetComponent<Mage>().MageData = tempData as MageData;
            }
            else if (componentType == typeof(Rogue))
            {
                prefab.GetComponent<Rogue>().RougueData = tempData as RogueData;
            }
            else if (componentType == typeof(Warrior))
            {
                prefab.GetComponent<Warrior>().warriorData = tempData as WarriorData;
            }
        }


        public static int PrefabExists(string prefabName, string path)
        {
            string[] enemies = AssetDatabase.FindAssets(prefabName, new[] { path });

            return enemies.Length;
        }

        static void ClearWindowData()
        {
            switch (dataSettings)
            {
                case SettingsType.MAGE:
                    EnemyDesignerWindow.MageInfo.prefab = null;
                    EnemyDesignerWindow.MageInfo.characterName = string.Empty;
                    EnemyDesignerWindow.MageInfo.maxHealth = 0;
                    EnemyDesignerWindow.MageInfo.maxEnergy = 0;
                    EnemyDesignerWindow.MageInfo.power = 0;
                    EnemyDesignerWindow.MageInfo.critChance = 0;
                    break;

                case SettingsType.WARRIOR:
                    EnemyDesignerWindow.WarriorInfo.prefab = null;
                    EnemyDesignerWindow.WarriorInfo.characterName = string.Empty;
                    EnemyDesignerWindow.WarriorInfo.maxHealth = 0;
                    EnemyDesignerWindow.WarriorInfo.maxEnergy = 0;
                    EnemyDesignerWindow.WarriorInfo.power = 0;
                    EnemyDesignerWindow.WarriorInfo.critChance = 0;
                    break;

                case SettingsType.ROGUE:
                    EnemyDesignerWindow.RogueInfo.prefab = null;
                    EnemyDesignerWindow.RogueInfo.characterName = string.Empty;
                    EnemyDesignerWindow.RogueInfo.maxHealth = 0;
                    EnemyDesignerWindow.RogueInfo.maxEnergy = 0;
                    EnemyDesignerWindow.RogueInfo.power = 0;
                    EnemyDesignerWindow.RogueInfo.critChance = 0;
                    break;
            }
        }
    }
}