using UnityEngine;

[CreateAssetMenu(fileName = "New Localization Entry", menuName = "Localization/Entry")]
public class LocalizationEntry : ScriptableObject
{
    public string key;
    public string en; // English
    public string fr; // French
    public string zh; // Chinese

}
