using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    public GameObject bow;
    public BowScript bowScript;

    [SerializeField]
    private Image foregroundImage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bow.activeSelf == true)
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }

        foregroundImage.fillAmount = 1f / bowScript.chargeMax*bowScript.charge;
    }
}
