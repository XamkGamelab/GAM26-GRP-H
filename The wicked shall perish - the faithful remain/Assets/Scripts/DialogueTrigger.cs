using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}
