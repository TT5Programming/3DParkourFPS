using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image foreground;

    private Target target;

    void Start()
    {
        target = gameObject.GetComponentInParent<Target>();
    }


    // Update is called once per frame
    void Update()
    {
        foreground.fillAmount = 1 / target.maxHealth * target.health;
        transform.LookAt(GameObject.Find("Main Camera").transform);
    }
}
