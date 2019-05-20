using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Line", order = 1)]
public class Dialogue : ScriptableObject
{
    public string dialogue;
    public string optionAResponse;
    public float optionAVal;
    public string optionBResponse;
    public float optionBVal;
    public string optionCResponse;
    public float optionCVal;
    public float scoreEarned;
}
