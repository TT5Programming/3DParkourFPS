using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCounter : MonoBehaviour
{
    public GameObject gun;

    void Update()
    {
        if (gun.activeSelf == true)
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }
    }
}
