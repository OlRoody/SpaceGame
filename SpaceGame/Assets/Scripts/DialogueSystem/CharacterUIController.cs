﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CharacterUIController : MonoBehaviour
{
    public GameObject character;
    public GameObject optionAButton;
    public GameObject optionBButton;
    public GameObject optionCButton;
    public GameObject relationshipStatusMeter;
    public Text characterNameText;
    public Text dialogueContainerText;
    [HideInInspector]
    public CharacterController characterController;

    [HideInInspector]
    private Button optionAScript;
    [HideInInspector]
    private Button optionBScript;
    [HideInInspector]
    private Button optionCScript;

    // Start is called before the first frame update
    void Start()
    {
        //SetCharacterController();

        // set components from gameobjects for easier interaction
        optionAScript = optionAButton.GetComponent<Button>();
        optionAScript = optionBButton.GetComponent<Button>();
        optionAScript = optionCButton.GetComponent<Button>();

        //LoadCharacterUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCharacterController()
    {
        characterController = character.GetComponent<CharacterController>();
    }

    public void SetCharacterName()
    {
        characterNameText.text = characterController.characterInfo.name;
    }

    public void SetDialogueText()
    {
        dialogueContainerText.text = characterController.currentDialogue.dialogue;
    }

    public void ProcessOptionAClick()
    {
        Debug.Log("Clicked on A");
        characterController.ProcessOption(characterController.currentDialogue.optionAVal);
        LoadCharacterUI();
    }

    public void ProcessOptionBClick()
    {
        Debug.Log("Clicked on B");
        characterController.ProcessOption(characterController.currentDialogue.optionBVal);
        LoadCharacterUI();
    }

    public void ProcessOptionCClick()
    {
        Debug.Log("Clicked on C");
        characterController.ProcessOption(characterController.currentDialogue.optionCVal);
        LoadCharacterUI();
    }

    public void LoadCharacterUI()
    {
        SetCharacterName();
        SetDialogueText();
    }
}
