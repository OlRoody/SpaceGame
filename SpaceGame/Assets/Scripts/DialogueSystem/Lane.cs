using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Lane", order = 3)]
public class Lane : ScriptableObject
{
    public Set[] sets;

    public void ResetLane()
    {
        foreach (Set set in sets)
        {
            set.ResetSet();
        }
    }
}
