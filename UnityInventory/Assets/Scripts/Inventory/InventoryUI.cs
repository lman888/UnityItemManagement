using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start ()
    {
        inventory = Inventory.instance;

        //We subscribe to the delegate 
        inventory.onItemChangeCallback += UpdateUI;

        //Gets all the itemsParent children and pushes them into slots
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void UpdateUI()
    {
        Debug.Log("Updateing UI");

        //Loops through all the slots in the inventory
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                //Adds an item to the slot at position i
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
