using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템 종류, 수량을 나타내는 클래스입니다
/// </summary>
[System.Serializable]
public class ItemStack
{
    public int ItemID;
    public int count;
    /// <summary>
    /// 빈 인벤토리 슬롯 (ItemID = -1, count = 0)을 나타냅니다<br/>
    /// 추가된 버전 : Indev 8
    /// </summary>
    public static ItemStack Empty => new ItemStack(-1, 0);


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
    public ItemStack Copy()
    {
        return new ItemStack(ItemID, count);
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
