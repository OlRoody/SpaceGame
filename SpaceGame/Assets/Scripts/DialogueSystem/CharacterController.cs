using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour
{
    public TextAsset dialoguesJsonFile;
    public List<Dialogue> dialogues = new List<Dialogue>();
    public CharacterInfo characterInfo;
    [HideInInspector]
    public Dialogue currentDialogue;
    public int currentDialoguePosition;
    public FloatGameEvent adjustAffectionLevel;
    public GameEvent triggerRandomEvent;


    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void LoadDialogueObjects()
    {
        string dialoguesFileText = dialoguesJsonFile.text;
        char[] delimiters = { '\n' };
        string[] dialoguesText = dialoguesFileText.Split(delimiters);
        foreach (string dialogueJsonText in dialoguesText)
        {
            dialogues.Add(JsonUtility.FromJson<Dialogue>(dialogueJsonText));
        }
    }

    public void SetCurrentDialogue(int index)
    {
        currentDialogue = dialogues[index];
    }

    public void CheckForTriggers()
    {
        if (currentDialogue.isSavePoint)
        {
            characterInfo.savedDialoguePosition = currentDialoguePosition;
        }
        if (currentDialogue.triggersRandomEvent)
        {
            triggerRandomEvent.Invoke();
        }
    }

    public void CheckAffectionMilestones()
    {
        Debug.Log(string.Format("Current Affection Level: {0}", characterInfo.currentAffectionLevel));
        if (characterInfo.currentAffectionLevel < characterInfo.milestone1)
        {
            Debug.Log("I hate you! Get out of here!");
        }
        else if (characterInfo.currentAffectionLevel >= characterInfo.milestone1 && characterInfo.currentAffectionLevel < characterInfo.milestone2)
        {
            Debug.Log("You seem interesting. Let's talk.");
        }
        else if (characterInfo.currentAffectionLevel >= characterInfo.milestone2 && characterInfo.currentAffectionLevel < characterInfo.milestone3)
        {
            Debug.Log("I think you are pretty cute. Wanna hang out?");
        }
        else if (characterInfo.currentAffectionLevel >= characterInfo.milestone3 && characterInfo.currentAffectionLevel < characterInfo.milestone4)
        {
            Debug.Log("You are the best thing since sliced bread. Wanna date?");
        }
        else if (characterInfo.currentAffectionLevel >= characterInfo.milestone4)
        {
            Debug.Log("You are my soulmate!");
        }
    }

    public void ProcessOption(float optionImpact)
    {
        characterInfo.currentAffectionLevel = Mathf.Clamp(characterInfo.currentAffectionLevel + optionImpact, 0f, 5f);
        CheckAffectionMilestones();
        CheckAffectionChange();
        currentDialoguePosition = Mathf.Clamp(currentDialoguePosition + 1, 0, dialogues.Count - 1);
        SetCurrentDialogue(currentDialoguePosition);
        CheckForTriggers();
    }

    public void LoadCharacter()
    {
        LoadDialogueObjects();
        SetCurrentDialogue(characterInfo.savedDialoguePosition);
    }

    public void CheckAffectionChange()
    {
        if (characterInfo.currentAffectionLevel < Const.HALF_HEART)
        {
            adjustAffectionLevel.Invoke(Const.ZERO_HEART);
        }

        CheckHeartValue(Const.HALF_HEART, Const.ONE_HEART);
        CheckHeartValue(Const.ONE_HEART, Const.ONE_AND_HALF_HEART);
        CheckHeartValue(Const.ONE_AND_HALF_HEART, Const.TWO_HEART);
        CheckHeartValue(Const.TWO_HEART, Const.TWO_AND_HALF_HEART);
        CheckHeartValue(Const.TWO_AND_HALF_HEART, Const.THREE_HEART);
        CheckHeartValue(Const.THREE_HEART, Const.THREE_AND_HALF_HEART);
        CheckHeartValue(Const.THREE_AND_HALF_HEART, Const.FOUR_HEART);
        CheckHeartValue(Const.FOUR_HEART, Const.FOUR_AND_HALF_HEART);
        CheckHeartValue(Const.FOUR_AND_HALF_HEART, Const.FIVE_HEART);

        if (characterInfo.currentAffectionLevel >= Const.FIVE_HEART)
        {
            adjustAffectionLevel.Invoke(Const.FIVE_HEART);
        }
    }

    public void CheckHeartValue(float initialHeart, float greaterHeart)
    {
        if (characterInfo.currentAffectionLevel >= initialHeart && characterInfo.currentAffectionLevel < greaterHeart)
        {
            adjustAffectionLevel.Invoke(initialHeart);
        }
    }
}
