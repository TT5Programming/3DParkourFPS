using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private Rooms roomsScript;

    void Start()
    {
        roomsScript = GameObject.Find("GameHandler").GetComponent<Rooms>();
        roomsScript.rooms.Add(this.gameObject);
    }
}
