using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStack
{
    public int ItemID;
    public int count;
    

    public ItemStack(int ItemID, int count)
    {
        this.ItemID = ItemID;
        this.count = count;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Item GetItem()
    {
        return GameObject.Find("Register").GetComponent<Register>().items[ItemID];
    }
    public static bool operator ==(ItemStack a, ItemStack b)
    {
        return (a.ItemID == b.ItemID) && (a.count == b.count);
    }
    public static bool operator !=(ItemStack a, ItemStack b)
    {
        return (a.ItemID != b.ItemID) || (a.count != b.count);
    }
}
