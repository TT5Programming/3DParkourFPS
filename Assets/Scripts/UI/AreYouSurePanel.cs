using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreYouSurePanel : MonoBehaviour
{
    public GameObject panel;

        void Start()
    {
        panel.SetActive(false);
    }

    public void Activate()
    {
        panel.SetActive(true);
    }

    public void Deactivate()
    {
        panel.SetActive(false);
    }
}
