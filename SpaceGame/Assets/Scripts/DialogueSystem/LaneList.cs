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

                    // Testing
                    dialogue.dialogue = lane.name + " : " + set + " : " + dialogue + " : " + Const.defaultDialogueLine;
                    dialogue.optionAResponse = lane.name + " : " + set + " : " + dialogue + " : " + Const.defaultAResponse;
                    dialogue.optionBResponse = lane.name + " : " + set + " : " + dialogue + " : " + Const.defaultBResponse;
                    dialogue.optionCResponse = lane.name + " : " + set + " : " + dialogue + " : " + Const.defaultCResponse;
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
