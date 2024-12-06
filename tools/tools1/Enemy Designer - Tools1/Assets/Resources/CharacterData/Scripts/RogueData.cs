using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "new Rouge Data", menuName = "Character Data/Rouge")]
public class RogueData : CharacterData
{
    public RogueWpnType wpnType;
    public RogueStrategyType strategyType;
}
