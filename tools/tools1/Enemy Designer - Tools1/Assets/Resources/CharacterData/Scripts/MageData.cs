using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "new Mage Data", menuName = "Character Data/Mage")]
public class MageData : CharacterData
{
    public MageDmgType DmgType;
    public MageWpnType WpnType;
}
