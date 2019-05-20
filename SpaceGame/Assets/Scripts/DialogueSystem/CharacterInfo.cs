using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    public string characterName;
    public float currentAffectionLevel;
    public Const.Milestones currentMilestone;
    public float milestone1;
    public float milestone2;
    public float milestone3;
    public float milestone4;
}
