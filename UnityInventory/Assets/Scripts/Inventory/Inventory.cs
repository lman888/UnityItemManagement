using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    //Creates a static variable
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then one inventory of Inventory found!");
            return;
        }
        //Sets the instance to this inventory component
        instance = this;
    }

    #endregion

    //A delegate an event that we can subscribe different methods to and when it is triggered
    //all subscribed methods will be called  
    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;

    public int space = 20;
    public List<Item> items = new List<Item>();

    //Adds an item on the array
    public bool Add (Item item)
    {
        //If our item is not a default item add it to the array
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);

            if (onItemChangeCallback != null)
            {
                //This means we are triggering the delegate
                onItemChangeCallback.Invoke();
            }
    
        }
        return true;
    }

    //Removes an item from the array
    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangeCallback != null)
        {
            //This means we are triggering the delegate
            onItemChangeCallback.Invoke();
        }
    }
}
