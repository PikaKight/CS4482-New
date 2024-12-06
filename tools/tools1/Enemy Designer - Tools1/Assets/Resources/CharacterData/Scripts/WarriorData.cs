using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "new Warrior Data", menuName = "Character Data/Warrior")]
public class WarriorData : CharacterData
{
    public WarriorClassType WarriorClassType;
    public WarriorWpnType WarriorWpnType;
}
