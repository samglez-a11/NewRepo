using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private string[] _dialogue;

    private DialogueManager _dialogueManager;

    private void Start()
    {

        _dialogueManager = FindObjectOfType<DialogueManager>();// para singletons
        if(_dialogueManager == null)
        {
            Debug.Log("NO se encontro el dialogueManager en la escena");
        }

    }

    public override void Interact(PlayerController playerController)
    {
        _name = this.name;
        Debug.Log("El NPC "+ _name+" intectuo");
        //mandar los Dialogos
        _dialogueManager.SetDialogue(_name,_dialogue);
    }

}
