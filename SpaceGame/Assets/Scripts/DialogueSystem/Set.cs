using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Set", order = 2)]
public class Set : ScriptableObject
{
    public bool isPassed;
    public float scoreEarned;
    public Dialogue[] dialogues;

    public bool CheckForPassing()
    {
        float currentScore = 0f;
        float possibleScore = 0f;
        foreach(Dialogue dialogue in dialogues)
        {
            currentScore += dialogue.scoreEarned;
            possibleScore += GetLargestResponseVal(dialogue);
        }
        if (currentScore >= possibleScore * Const.dialoguePassingPercentage)
        {
            isPassed = true;
            scoreEarned = currentScore;
            return true;
        }
        return false;
    }

    public float GetLargestResponseVal(Dialogue passedDialogue)
    {
        List<float> vals = new List<float>{ passedDialogue.optionAVal, passedDialogue.optionBVal, passedDialogue.optionCVal };
        vals.Sort();
        return vals[0];
    }

    public void ResetSet()
    {
        isPassed = false;
        scoreEarned = 0f;
        foreach (Dialogue dialogue in dialogues)
        {
            dialogue.scoreEarned = 0f;
        }
    }
}
