using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{
    public Button scene_button;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {

        scene_button.onClick.AddListener(ChangeScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeScene()
    {
        AudioListener.volume = 1f; // unmute the audio
        Time.timeScale = 1f; // Unfreeze time
        // Load the scene with the given name
        SceneManager.LoadScene(sceneName);
    }
}
