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

    int nextDialogue = 0;//Uusi per if lause 
    float[] dialogueThreshold = { 100f, 1000f, 100000f, 100000000f }; // esimerkkejä, on siis lista asioist, jokasel floatil on oma int eli 100f on 0, 1000f on 1, ja niin edelleen

    GlobalResources globalResources;

    //Puhujat
    public GameObject townOfficial;


    bool dialogueStarted = false;

    private Queue<string> sentences;

    void Start()
    {
        Debug.Log(GlobalResources.populationCount);
        Debug.Log(dialogueStarted);
        sentences = new Queue<string>();
        
    }
    
    void Update()
    {

        

        
        if (GlobalResources.populationCount >= dialogueThreshold[nextDialogue] && !dialogueStarted && nextDialogue < dialogueThreshold.Length)
        {
            dialogueStarted = true;
            TownGrowth(nextDialogue); // sun testi functio
            nextDialogue++;
        }

    }
    IEnumerator TriggerPause()//Jos tarvii pistää aikaa väliin
    {
        
        yield return new WaitForSeconds(1);
        dialogueStarted = false;
        Debug.Log(dialogueStarted);
    }

    //Dialogue management Älä koske 
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
    IEnumerator TypeSentence(string sentence)//Kirjoittaa kirjaimet per dialogi 
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
        nameText.text = string.Empty;
        dialogueText.text = string.Empty;
        Debug.Log("End of the converstation.");
    }
    //End of dialogue management

    // functio millä kutsutaan puhuja 
    void TownGrowth(int dialogueNumber)
    {
        switch (dialogueNumber) //kyllä switch taas tosi hyvii
        {
            case 0:
                townOfficial.GetComponent<DialogueTrigger>().TriggerDialogue();
                dialogueStarted = false;
                break;
            case 1:
                townOfficial.GetComponent<DialogueTrigger>().TriggerDialogue();//jotain taas sun dialogue 2 toiselle thresholdille
                dialogueStarted = false;
                break;
                // ja niin edelleen
            }
        }
    }
