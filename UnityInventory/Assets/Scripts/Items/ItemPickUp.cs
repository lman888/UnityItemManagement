using UnityEngine;

//Derives from the virtual interactable class
public class ItemPickUp : Interactable
{
    public Item item;

    //Overrides the Interact function
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }


    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        //Creates a reference to our Inventory script and sets it to a bool
        bool wasPickedUp = Inventory.instance.Add(item);

        //If we picked up the item
        if (wasPickedUp)
        {
            //Destroys the game object
            Destroy(gameObject);
        }
    }
}
