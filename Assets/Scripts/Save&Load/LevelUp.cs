using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public LevelController levelController;

    private void Start()
    {
        levelController = GameObject.Find("GameHandler").GetComponent<LevelController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            string nextLevel = levelController.nextLevel;
            levelController.LoadLevel(nextLevel);
        }
    }
}
