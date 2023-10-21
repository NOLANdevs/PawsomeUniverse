using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Button[] optionButton;
    public GameObject dialogueBox;

    private Queue<string> sentences;
    private Dialogue current;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        // clear sentence
        sentences.Clear();
        current = dialogue;

        // after a sentence que the next sentence
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayChoices(dialogue.playerResponse);

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            // if run out of sentence end the dialogue
            if (sentences.Count == 0)
            {
                DisplayChoices(current.playerResponse);
            }
            else
            {
                EndDialogue();
            }
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void DisplayChoices(string[] choices)
    {
        for (int i = 0; i < optionButton.Length; i++)
        {
            if (i < choices.Length)
            {
                if (optionButton[i] != null)
                {
                    optionButton[i].gameObject.SetActive(true);
                    optionButton[i].GetComponentInChildren<Text>().text = choices[i];
                }
                else
                {
                    Debug.Log("Choice button is not assigned");
                }
            }
            else
            {
                optionButton[i].gameObject.SetActive(false);
            }
        }
    }

    public void DisplayChoicesOnClick()
    {
        if (current != null)
        {
            DisplayChoices(current.playerResponse);
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        Debug.Log("End of Conversation");
    }

    public void OnChoice(int index)
    {
        string responseSentence = current.responseSentences[index];
        dialogueText.text = responseSentence;

        foreach (Button button in optionButton)
        {
            button.gameObject.SetActive(false);
        }
    }

}
