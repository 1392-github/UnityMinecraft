using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    public int textureID;
    public int maxStack;
    public int placedBlockID;
    public string itemName;
    [System.Obsolete("Item Ŭ������ �����ڴ� ����� �������� �ʽ��ϴ� (�ν����� â���� ������ �ּ���)")]
    public Item(int textureID, int maxStack, int placedBlockID, string itemName)
    {
        this.textureID = textureID;
        this.maxStack = maxStack;
        this.placedBlockID = placedBlockID;
        this.itemName = itemName;
    }
}
