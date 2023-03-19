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
    [System.Obsolete("Item 클래스의 생성자는 사용을 권장하지 않습니다 (인스펙터 창에서 설정해 주세요)")]
    public Item(int textureID, int maxStack, int placedBlockID, string itemName)
    {
        this.textureID = textureID;
        this.maxStack = maxStack;
        this.placedBlockID = placedBlockID;
        this.itemName = itemName;
    }
}
