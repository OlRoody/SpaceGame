using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public IntValue currentCharacter;
    public List<GameObject> characters;
    private CharacterUIController characterUIController;
    // Start is called before the first frame update
    void Start()
    {
        characterUIController = gameObject.GetComponent<CharacterUIController>();

        // Load up the characters before anything else happens
        foreach (GameObject character in characters)
        {
            character.GetComponent<CharacterController>().LoadCharacter();
        }

        InitiateCharacter(currentCharacter.index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateCharacter(int index)
    {
        characterUIController.character = characters[index];
        characterUIController.SetCharacterController();
        characterUIController.LoadCharacterUI();
        characters[index].GetComponent<CharacterController>().CheckAffectionMilestones();
        characters[index].GetComponent<CharacterController>().CheckForTriggers();
    }

    public void ProcessRandomEvent()
    {
        Debug.Log("This is a random event!");
    }
}
