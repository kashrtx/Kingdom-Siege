using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class winningDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    // Character Sprites
    public Sprite narrator;
    public Sprite Shinji;
    public Sprite King;
    public Sprite Princess;


    // BG
    public RawImage backgroundImage;
    public Texture castle;


    // audio
    public AudioSource sfxSource;
    public AudioClip victoryMusic;

    // scene switcher after narration finished
    public string sceneName;

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
    }

   IEnumerator PlayDialogueSequence()
    {
        // castle scene
        backgroundImage.texture = castle;
        sfxSource.Stop();
        sfxSource.PlayOneShot(victoryMusic);
        sfxSource.loop = true;
        sfxSource.volume = 0.5f;

         // Narrator dialogue
        dialogueManager.StartDialogue("Narrator", "Well done! You defended the kingdom and showed that even a lazy college gamer can rise to the occasion.", narrator);
        // Wait for the first dialogue to finish typing
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        // Wait for user input to proceed
        yield return new WaitUntil(() => dialogueManager.canProceed);
        // Reset canProceed for the next line
        dialogueManager.canProceed = false;

        // first dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "I…I actually did it? No game overs. No save states. Just… victory.", Shinji);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // second dialogue
        dialogueManager.StartDialogue("King Ryker Goldenblade", "Marvelous! You've secured Goldhaven, Shinji! Riches, honor, and more await you!", King);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

         // third dialogue
        dialogueManager.StartDialogue("Princess Aria Goldenblade", "Th-That was… not bad. I mean, for someone who looked so hopeless before, you actually… protected us. Don't get a big head about it, but I… suppose you've earned a bit of respect.", Princess);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

         // fourth dialogue
        dialogueManager.StartDialogue("King Ryker Goldenblade", "Ah, splendid! Now… time to prepare for your wedding, Shinji!", King);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 5th dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "Hehhhhhh!?!?", Shinji);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 14th dialogue
        dialogueManager.StartDialogue("Princess Aria Goldenblade", "Hehhhhhh!?!?!?!?", Princess);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // Narrator dialogue
        dialogueManager.StartDialogue("Narrator", "And so, Shinji lived happily ever after, not locked in his room, and oh-so-stuck in another world with absolutely no return ticket. The end! …Wait, I’m stuck here too?!", narrator);
        // Wait for the first dialogue to finish typing
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        // Wait for user input to proceed
        yield return new WaitUntil(() => dialogueManager.canProceed);
        // Reset canProceed for the next line
        dialogueManager.canProceed = false;

        // finish dialogue
        dialogueManager.CloseDialogue();
        Debug.Log("All dialogues completed!");
        SceneManager.LoadScene(sceneName);
    }
}
