using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Inventory inventory;
    public PlayerMovement playerMovement;

    public GameObject messagePanel;
    public Text messageText;

    // Start is called before the first frame update
    void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach(Transform Slot in inventoryPanel)
        {
            Image image = Slot.GetChild(0).GetComponent<Image>();
            

            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                Slot.gameObject.GetComponent<InventorySlot>().itemInSlot = playerMovement.mItemToPickup.ItemInSlot;

                break;
            }
        }
    }

    public void OpenMessagePanel(string text)
    {
        messageText.text = text;
        messagePanel.SetActive(true);
    }
    public void CloseMessagePanel()
    {
        messagePanel.SetActive(false);
    }
}
