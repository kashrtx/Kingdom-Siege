using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI nameText;        // Character name
    public TextMeshProUGUI dialogueText;    // Dialogue text
    public Image characterImage;            // Character image
    public Image dialogueSystem;
    
    [Header("Typing Settings")]
    public float typingSpeed = 0.05f;       // Speed of typing effect
    public AudioSource typeSound;           // Audio source for typing sound
    
    private string currentDialogue;         // Store full dialogue
    public bool isTyping = false;          // Check if text is being typed
    public bool canProceed = false;
    private Coroutine typingCoroutine;      // Store typing coroutine
    
    // Call this method to start new dialogue
    public void StartDialogue(string charName, string dialogue, Sprite charImage)
    {
         // Show the UI elements
        dialogueSystem.gameObject.SetActive(true);

        // Set character name and image
        nameText.text = charName;
        characterImage.sprite = charImage;
        
        // Store dialogue and start typing
        currentDialogue = dialogue;
        
        // If already typing, stop the previous coroutine
        if(typingCoroutine != null)
            StopCoroutine(typingCoroutine);
            
        // Start new typing coroutine
        typingCoroutine = StartCoroutine(TypeDialogue());
    }
    
    IEnumerator TypeDialogue()
    {
        isTyping = true;
        dialogueText.text = "";
        
        // Type each character one by one
        foreach(char letter in currentDialogue.ToCharArray())
        {
            dialogueText.text += letter;
            
            // Play typing sound if audio source exists
            if(typeSound != null)
                typeSound.Play();
                
            yield return new WaitForSeconds(typingSpeed);
        }
        
        isTyping = false;
    }
    
    public bool CanProceed
    {
        get => canProceed;
        set => canProceed = value;
    }

    // Update method: wait for user input
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect mouse click
        {
            if (isTyping)
            {
                // If still typing, complete the dialogue immediately
                StopCoroutine(typingCoroutine);
                dialogueText.text = currentDialogue;
                isTyping = false;
            }
            else
            {
                // Allow proceeding to the next dialogue
                canProceed = true;
            }
        }
    }

    public void CloseDialogue()
    {
        dialogueSystem.gameObject.SetActive(false);
    }

}