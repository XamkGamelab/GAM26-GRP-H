using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    int currentpage = 1;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();   
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting dialogue with" +  dialogue.name);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) 
        { 
            sentences.Enqueue(sentence); 
        }

        DisplayNextSentence();
    }



    public void ButtonNextPage()
    {
            int totalpages = dialogueText.textInfo.pageCount;   

            if (currentpage < totalpages)
            {
                currentpage++;
                dialogueText.pageToDisplay++;
            }
    }
    public void ButtonPrevPage()
    {
            int totalpages = dialogueText.textInfo.pageCount;   

            if (currentpage > 0)
            {
                currentpage--;
                dialogueText.pageToDisplay--;
            }
    }
   
    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
       // dialogueText.text = sentence;
        Debug.Log(sentence);
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue ()
    {
        Debug.Log("End of the conversation.");
    }
}
