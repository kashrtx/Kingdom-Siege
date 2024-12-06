using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class CharacterDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    // Character Sprites
    public Sprite narrator;
    public Sprite shinji_ni; // non-isekai version wearing casual clothes
    public Sprite Shinji; // isekai version with medieval clothes
    public Sprite truck;
    public Sprite King;
    public Sprite Princess;


    // BG
    public RawImage backgroundImage;
    public Texture store;
    public Texture castle;


    // audio
    public AudioSource sfxSource;
    public AudioClip crashSound;
    public AudioClip outsideStore;
    public AudioClip Kingdom;

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
        // store scene
        backgroundImage.texture = store;
        sfxSource.PlayOneShot(outsideStore);
        sfxSource.loop = true;

        // Narrator dialogue
        dialogueManager.StartDialogue("Narrator", "You are Shinji Kazuma, a lazy college student who spends every waking moment locked in his room, skipping lectures, and glued to the screen playing tower defense games. Outside life? Bah, too much effort. (BTW click to continue)", narrator);
        // Wait for the first dialogue to finish typing
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        // Wait for user input to proceed
        yield return new WaitUntil(() => dialogueManager.canProceed);
        // Reset canProceed for the next line
        dialogueManager.canProceed = false;

        // First dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "Man, I need a break from all those lectures… or well, from skipping them. Let's see… convenience store’s got half-priced sandwiches today.", shinji_ni);
        // Wait for the first dialogue to finish typing
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        // Wait for user input to proceed
        yield return new WaitUntil(() => dialogueManager.canProceed);
        // Reset canProceed for the next line
        dialogueManager.canProceed = false;

        // Second dialogue
        dialogueManager.StartDialogue("Truck-Kun", "Vroom Vroom Outta the way, buddy! Today's special delivery is your ticket to another world!", truck);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;
       
        // Third dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "Wait, what—?!", shinji_ni);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // crash sound
        dialogueManager.enabled = false;  
        sfxSource.loop = false;
        sfxSource.Stop();
        sfxSource.PlayOneShot(crashSound);
        yield return new WaitForSeconds(crashSound.length);
        dialogueManager.enabled = true;  
       
    
         // Narrator dialogue
        dialogueManager.StartDialogue("Narrator", "Yeah he got hit by a truck...", narrator);
        // Wait for the first dialogue to finish typing
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        // Wait for user input to proceed
        yield return new WaitUntil(() => dialogueManager.canProceed);
        // Reset canProceed for the next line
        dialogueManager.canProceed = false;

        
  

        // castle scene
        backgroundImage.texture = castle;
        sfxSource.Stop();
        sfxSource.PlayOneShot(Kingdom);
        sfxSource.loop = true;
        sfxSource.volume = 0.5f;

         // Narrator dialogue
        dialogueManager.StartDialogue("Narrator", "But instead of waking up in a hospital, Shinji opened his eyes to find himself in a grand medieval hall. Yup, you guessed it...he'd been isekai'd straight into the Goldhaven Kingdom. Typical... Wait why am I here?", narrator);
        // Wait for the first dialogue to finish typing
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        // Wait for user input to proceed
        yield return new WaitUntil(() => dialogueManager.canProceed);
        // Reset canProceed for the next line
        dialogueManager.canProceed = false;

        // 4th dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "Ugh… where am I? This isn't my room. Hey, why's everyone dressed like it's a medieval faire? What am I wearing?!?!?", Shinji);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 5th dialogue
        dialogueManager.StartDialogue("King Ryker Goldenblade", "Shinji Kazuma, I have summoned you! You are the one with the gift for defense, correct? Err… you do know something about defending a kingdom, right?", King);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

         // 6th dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "What? Look, old man, I'm just a college kid who's into tower defense games. I don't know anything about actual battlefields!", Shinji);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 7th dialogue
        dialogueManager.StartDialogue("King Ryker Goldenblade", "Then you must learn quickly. Our walls are failing, our people are suffering. Goblins, Demons, Slimes....these monsters grow bolder by the day!", King);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

         // 8th dialogue
        dialogueManager.StartDialogue("Princess Aria Goldenblade", "Him? Father, you truly believe this… slacker can protect us? I'd rather trust a goblin to handle siege defenses than this one.", Princess);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 9th dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "Hey, I'm not exactly thrilled about this either. But if building defenses is what it takes to get home safely, I'll give it a shot.", Shinji);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

         // 10th dialogue
        dialogueManager.StartDialogue("King Ryker Goldenblade", "Oh well um.. you can't go back cause I don't know how to do that. Anyways Our best strategist Erwin Smith died defending my daughter. Now we turn to you. Succeed, and you shall have wealth, honor...and yes, possibly Princess Aria's hand in marriage.", King);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 11th dialogue
        dialogueManager.StartDialogue("Princess Aria Goldenblade", "Over my dead body…", Princess);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 12th dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "Fine, fine. I don't want to marry anyone anyway. Just… give me what I need to set up these defenses. If I can keep my towers from falling in a game, I can keep your walls from crumbling in reality. It Sucks that I am stuck here!", Shinji);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 13th dialogue
        dialogueManager.StartDialogue("King Ryker Goldenblade", "Then waste no time! Our enemies approach. Prove your worth, Shinji Kazuma, Chief of Defense!", King);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 14th dialogue
        dialogueManager.StartDialogue("Princess Aria Goldenblade", "Please be careful! And don't take it the wrong way! It's not like I like you or anything!!!!", Princess);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 15th dialogue
        dialogueManager.StartDialogue("Shinji Kazuma", "What was that? Sheesh! Alright, let's do this… Because I'm guessing there's no 'Alt+F4' to bail me out of this world!", Shinji);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // 16th dialogue
        dialogueManager.StartDialogue("King Ryker Goldenblade", "Alt-F4? Sounds like a strange incantation. Does it summon dragons or just confuse the enemy? Bah, no matter! Let's get on with it!", King);
        yield return new WaitUntil(() => !dialogueManager.isTyping);
        yield return new WaitUntil(() => dialogueManager.canProceed);
        dialogueManager.canProceed = false;

        // Narrator dialogue
        dialogueManager.StartDialogue("Narrator", "Do I need to remind you again? Click to continue... It starts now!", narrator);
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
