using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public KeyCode slotNumber;
    public Image image;
    public Color normal, active;
    public InventorySlot[] InventorySlots;
    public bool resetting, isActive;
    private int m = 0;
    public GameObject itemInSlot = null;
    
    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            image.color = active;
            if (itemInSlot != null)
            {
                itemInSlot.SetActive(true);
            }
        }
            if (resetting == true && m < InventorySlots.Length)
            {
                InventorySlots[m].Reset(slotNumber);
                m++;
            }
        else
        {
            resetting = false;
            m = 0;
        }
        if (Input.GetKeyDown(slotNumber))
        {
            if (itemInSlot != null)
            {
                isActive = true;
            }
             resetting = true;
            
        }
    }
    public void Reset(KeyCode numPressed)
    {
        if (slotNumber != numPressed)
        {
            if (itemInSlot != null)
            {
                itemInSlot.SetActive(false);
            }
            isActive = false;
            image.color = normal;
        }
    }
}
