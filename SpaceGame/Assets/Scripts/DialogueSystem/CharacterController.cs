using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour
{
    public LaneList lanes;
    public CharacterInfo characterInfo;
    [HideInInspector]
    public Lane currentLane;
    [HideInInspector]
    public Set currentSet;
    [HideInInspector]
    public Dialogue currentDialogue;
    public int currentDialoguePosition;

    // Use this for initialization
    void Start()
    {
   
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SetCurrentLane()
    {
        currentLane = lanes.list[(int) characterInfo.currentMilestone];
    }

    public void SetCurrentSet()
    {
        currentSet = GetRandomSet();
    }

    public void SetCurrentDialogue()
    {
        currentDialogue = currentSet.dialogues[currentDialoguePosition];
    }

    public Set GetRandomSet()
    {
        System.Random random = new System.Random();
        Set possibleSet = currentLane.sets[0];
        int laneLength = currentLane.sets.Length;
        int currentLaneSetCount = 0;
        do
        {
            currentLaneSetCount++;
            possibleSet = currentLane.sets[random.Next(currentLane.sets.Length)];
        }
        while (possibleSet.isPassed && currentLaneSetCount <= laneLength);
        if (currentLaneSetCount > laneLength)
        {
            currentLane.ResetLane();
            return GetRandomSet();
        }
        currentDialoguePosition = 0;
        return possibleSet;
    }

    public Const.Milestones GetPotentialMilestone()
    {
        if (characterInfo.currentAffectionLevel < characterInfo.milestone1)
        {
            return Const.Milestones.Annoying;
        }
        else if (characterInfo.currentAffectionLevel >= characterInfo.milestone1 && characterInfo.currentAffectionLevel < characterInfo.milestone2)
        {
            return Const.Milestones.Colleague;
        }
        else if (characterInfo.currentAffectionLevel >= characterInfo.milestone2 && characterInfo.currentAffectionLevel < characterInfo.milestone3)
        {
            return Const.Milestones.Friend;
        }
        else if (characterInfo.currentAffectionLevel >= characterInfo.milestone3 && characterInfo.currentAffectionLevel < characterInfo.milestone4)
        {
            return Const.Milestones.SignificantOther;
        }
        else
        {
            return Const.Milestones.Soulmate;
        }
    }

    public void ProcessOption(float optionImpact)
    {
        currentDialogue.scoreEarned = optionImpact;
        if (currentDialoguePosition == currentSet.dialogues.Length - 1) // check if it is the end of the dialogue
        {
            if (!currentSet.CheckForPassing()) // if the dialogue was not passed reset it and pick a random new one
            {
                currentSet.ResetSet();
                SetCurrentSet();
            }
            else // add the score to the affection meter and check to set a new milestone. Load the new Lane/Set/Dialogue
            {
                characterInfo.currentAffectionLevel += currentSet.scoreEarned;
                CheckForMilestoneChange();
                return;
            }
        }
        else // load the next line
        {
            currentDialoguePosition++;
        }
        SetCurrentDialogue();
    }

    public bool CheckForMilestoneChange()
    {
        Const.Milestones potentialNewMilestone = GetPotentialMilestone();
        if (!potentialNewMilestone.Equals(characterInfo.currentMilestone))
        {
            characterInfo.currentMilestone = potentialNewMilestone;
            currentLane.ResetLane();
            LoadCharacterDialogue();
            return true;
        }
        return false;
    }

    public void LoadCharacterDialogue()
    {
        SetCurrentLane();
        SetCurrentSet();
        currentSet.ResetSet();
        SetCurrentDialogue();
    }
}
