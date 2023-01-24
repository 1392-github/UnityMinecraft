using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    public int textureID;
    public int maxStack;
    public int placedBlockID;
    public Item(int textureID, int maxStack, int placedBlockID)
    {
        this.textureID = textureID;
        this.maxStack = maxStack;
        this.placedBlockID = placedBlockID;
    }
}
