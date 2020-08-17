using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInventoryItem
{

    public GameObject player;
    public PlayerMovement playerMovement;
    public GameObject relatedItem;
    public string itemName;

    public string Name
    {
        get
        {
            return itemName;
        }
    }

    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public GameObject ItemInSlot
    {
        get
        {
            return relatedItem;
        }
    }

    public void OnPickup()
    {
        //grappleGun.SetActive(true);
        gameObject.SetActive(false);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerMovement.Collision(gameObject);
        }
    }*/
}
