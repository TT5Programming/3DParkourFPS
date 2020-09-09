using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject unitGameObject;
    private IUnit unit;
    public LevelController levelController;

    private void Awake()
    {
        unit = unitGameObject.GetComponent<IUnit>();
    }
    public void Save()
    {
        string currentLevel = levelController.currentLevel;
        PlayerPrefs.SetString("currentLevel", currentLevel);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            string currentLevel = PlayerPrefs.GetString("currentLevel");
            levelController.LoadLevel(currentLevel);
        }
        else
        {
            string level1 = levelController.level1;
            levelController.LoadLevel(level1);
        }
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Quit()
    {
        Application.Quit();
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
    }
}
