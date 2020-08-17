using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    public bool isSwinging;
    public Animator anim;
    public float damage = 25f;

    void Update()
    {
        anim.SetBool("isSwinging", isSwinging);
        if (Input.GetMouseButton(0))
        {
            isSwinging = true;
        }
        else
        {
            isSwinging = false;
        }
       
    }
}
