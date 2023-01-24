using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public ItemStack[] value;
    
    public int size;
    [Obsolete("ReadOnlySlot 속성은 권장하지 않으니 ItemEvent를 이용하세요")]
    public List<int> ReadOnlySlot;
    //public List<ItemEvent> Events = new List<ItemEvent>();
    /// <summary>
    /// 해당 인벤토리에서 아이템이 제거될 때 호출
    /// </summary>
    public UnityEvent<InventoryInsertAndRemoveEventArgs> OnRemoved;
    /// <summary>
    /// 해당 인벤토리에 아이템이 추가될 때 호출
    /// </summary>
    public UnityEvent<InventoryInsertAndRemoveEventArgs> OnInserted;

    //public ItemEvent test;
    //test = EditorGUILayout.ObjectField(test, typeof(ItemEvent), false) as ItemEvent;
    //public UnityEditor.MonoScript test2;
    void Start()
    {
        value = new ItemStack[size];
        for (int i = 0; i < size; i++)
        {
            value[i] = new ItemStack(-1, 0);
            //Debug.Log(i);
        }
    }
    void Update()
    {
    }
    // 해당 아이템을 인벤토리에 추가, 아이템을 성공적으로 넣으면 0, 칸이 부족하면 넣지 못한 아이템 수 반환
    public int AddItem(ItemStack item)
    {
        InventoryInsertAndRemoveEventArgs e = new InventoryInsertAndRemoveEventArgs { FromInventory = null, FromInventoryIndex = -1, Handled = false, InsertedItem = item, ToInventory = this, ToInventoryIndex = -1 };
        /*foreach (ItemEvent Event in Events)
        {
            Event.ItemInserted(ref e);
        }*/
        OnInserted.Invoke(e);
        if (e.Handled)
        {
            return item.count;
        }
        int i;
        bool flag = false;
        for (i = 0; i < 36; i++)
        {
            if ((value[i].ItemID == -1) || (value[i].ItemID == item.ItemID && value[i].count < 64))
            {
                flag = true;
                break;
            }
        }
        if (flag && item.ItemID != -1)
        {
            Debug.Log(i);
            if (value[i].ItemID == -1)
            {
                value[i].ItemID = item.ItemID;
                value[i].count = item.count;
                return 0;
            }
            else
            {
                value[i].count += item.count;
                if (value[i].count > 64) // 64개를 넘어간 경우
                {
                    int lack = value[i].count - 64;
                    value[i].count = 64;
                    return AddItem(new ItemStack(item.ItemID, lack)); // 부족한 아이템 넣기
                }
                return 0;
            }
        }
        return item.count;
    }
    public void RemoveItem(int slot, int usedCnt)
    {
        InventoryInsertAndRemoveEventArgs e = new InventoryInsertAndRemoveEventArgs { FromInventory = null, FromInventoryIndex = -1, Handled = false, InsertedItem = value[slot], ToInventory = this, ToInventoryIndex = -1 };
        OnRemoved.Invoke(e);
        value[slot].count -= usedCnt;
        if (value[slot].count <= 0)
        {
            value[slot].count = 0;
            value[slot].ItemID = -1;
        }
    }
}
