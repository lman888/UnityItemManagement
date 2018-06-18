using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gives our item a default item name and menu name
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //This data is shared by all items

    //Overrides the old name definition
    new public string name = "New Item";

    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
