using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ����, ������ ��Ÿ���� Ŭ�����Դϴ�
/// </summary>
[System.Serializable]
public class ItemStack
{
    public int ItemID;
    public int count;
    /// <summary>
    /// �� �κ��丮 ���� (ItemID = -1, count = 0)�� ��Ÿ���ϴ�<br/>
    /// �߰��� ���� : Indev 8
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
