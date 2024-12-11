using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class IngameDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    // Character Sprites
    public Sprite narrator;
    public Sprite Shinji;
    public Sprite King;


    // hide game UI while dialogue plays
    public GameObject gameUI;
    public GameObject dialogueBackground;

    // skip button
    public Button skip;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueManager != null)
        {
            StartCoroutine(PlayDialogueSequence());
        }
        else
        {
            Debug.LogError("DialogueManager is not assigned!");
        }

        skip.onClick.AddListener(OnSkipButtonClicked);
    }

   IEnumerator PlayDialogueSequence()
    {

        // turn off gameUI so dialogue focuses
        gameUI.SetActive(false);

        // Narrator dialogue
        dialogueManager.StartDialogue("Narrator", "Defend that castle behind you from three waves of enemies! You'll start with a set amount of gold...use it to buy towers and place them along the paths those pesky monsters will take. Different towers have different strengths, so choose and upgrade wisely. Ready to do some heroic clicking?", narrator);
        // Wait for the first dialogue to finish typing
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        // Wait for user input to proceed
        yield return new WaitUntil(() => dialogueManager.canProceed);
        // Reset canProceed for the next line
        dialogueManager.canProceed = false;

         // Narrator dialogue
        dialogueManager.StartDialogue("Narrator", "Archer Towers fire arrows that get faster and hit harder as you upgrade to level 3. Mage Towers? They slow enemies down more and more with each upgrade, perfect for crowd control. And Crossbow Towers? They're the snipers of your defense, gaining extra range, fire rate, and damage with each level.", narrator);
        // Wait for the first dialogue to finish typing
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        // Wait for user input to proceed
        yield return new WaitUntil(() => dialogueManager.canProceed);
        // Reset canProceed for the next line
        dialogueManager.canProceed = false;

         // Second dialogue
        dialogueManager.StartDialogue("King Ryker Goldenblade", "Shinji! Time is short! Place your towers along these paths. The Goblins come first—wily little creatures that run fast but don't let the gate take too many hits. Hurry!", King);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // third  dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "Alright, so I just… click and place these towers? No keyboard shortcuts for skipping lectures this time, I guess. Let's try the Archer Tower first since it's cheaper and should handle those Goblins. I'll get the hang of it with tougher enemies!", Shinji);
        // Wait for the first dialogue to finish typing
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        // Wait for user input to proceed
        yield return new WaitUntil(() => dialogueManager.canProceed);
        // Reset canProceed for the next line
        dialogueManager.canProceed = false;

        // 4th dialogue
        dialogueManager.StartDialogue("King Ryker Goldenblade", "Afterwards there will be Demons which are stronger and Slimes which are tanky. Spend your gold wisely!", King);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

       


        // finish dialogue
        dialogueManager.CloseDialogue();
        dialogueBackground.SetActive(false);
        Debug.Log("All dialogues completed!");
        gameUI.SetActive(true);
    }

    public void OnSkipButtonClicked()
    {   
        StopAllCoroutines();
        dialogueManager.CloseDialogue();
        dialogueBackground.SetActive(false);
        gameUI.SetActive(true);
    }
}
