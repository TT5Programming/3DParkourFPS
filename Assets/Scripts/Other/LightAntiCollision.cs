using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAntiCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag != "Level")
        {
            Destroy(gameObject);
        }
    }
}
