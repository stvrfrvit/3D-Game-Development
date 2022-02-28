using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : Interactable
{
    public DialogueUI ui;
    [TextArea]
    public string dialogue;

    public override void Activate()
    {
        ui.SetDialogueText(dialogue, true);
    }
}
