using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/LaneList", order = 4)]
public class LaneList : ScriptableObject
{
    public Lane[] list;

    public void SetDefaultResponseValues(float valA, float valB, float valC)
    {
        foreach (Lane lane in list)
        {
            foreach (Set set in lane.sets)
            {
                foreach (Dialogue dialogue in set.dialogues)
                {
                    dialogue.optionAVal = valA;
                    dialogue.optionBVal = valB;
                    dialogue.optionCVal = valC;
                }
            }
        }
    }

    public void ResetLaneList()
    {
        foreach (Lane lane in list)
        {
            lane.ResetLane();
        }
    }
}
