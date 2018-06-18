using UnityEngine;
using UnityEngine.UI;   //Whenever we are using UI in scripting we need to use this

public class InventorySlot : MonoBehaviour
{
    //Variables
    //Is a reference to our icon
    public Image icon;
    public Button removeButtom;

    //This will keep track of the curent item in the slot
    Item item;
	
    public void AddItem(Item newItem)
    {
        //Sets the new item we picked up to the item 
        item = newItem;

        //Enables the sprite icon
        icon.sprite = item.icon;
        icon.enabled = true;

        //Enables the remove button to appear
        removeButtom.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        //Disables the remove button
        removeButtom.interactable = false;
    }

    public void OnRemoveButton()
    {
        //Removes the item from the inventory
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
