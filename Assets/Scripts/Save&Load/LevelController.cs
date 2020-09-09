using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string currentLevel;
    public string level1;
    public string nextLevel;

    void Start()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        currentLevel = activeScene.name;
    }

    public void LoadLevel(string levelToLoad)
    {
            SceneManager.LoadScene(levelToLoad);
    }
}
