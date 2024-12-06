using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Localization Data", menuName = "Localization/Data")]
public class LocalizationData : ScriptableObject
{
    public List<LocalizationEntry> entries = new List<LocalizationEntry>();

}