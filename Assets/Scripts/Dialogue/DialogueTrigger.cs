using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueBox;
    public GameObject player;
    private float horizOffset = 0;
    private float vertOffset = 2.3f;

    private bool playerInRange = false;

    void Update()
    {
        // Track player position
        dialogueBox.transform.position = player.transform.position + new Vector3(horizOffset, vertOffset, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
           
            dialogueBox.SetActive(true);
            
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            
            dialogueBox.SetActive(false);
            
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}
