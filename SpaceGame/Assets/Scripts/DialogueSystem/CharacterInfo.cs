using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    public string characterName;
    public int savedDialoguePosition;
    public float currentAffectionLevel;
    public string greeting;
    public float milestone1;
    public float milestone2;
    public float milestone3;
    public float milestone4;
}
