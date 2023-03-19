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
    /// 해당 인벤토리에서 아이템이 제거되기 전에호출
    /// </summary>
    public UnityEvent<InventoryInsertAndRemoveEventArgs> OnBeforeRemoved;
    /// <summary>
    /// 해당 인벤토리에 아이템이 추가되기 전에 호출
    /// </summary>
    public UnityEvent<InventoryInsertAndRemoveEventArgs> OnBeforeInserted;
    /// <summary>
    /// 해당 인벤토리에 아이템이 추가된 후 호출 (취소 불가능)<br/>
    /// 추가된 버전 : Indev 9
    /// </summary>
    public UnityEvent<InventoryInsertAndRemoveEventArgs> OnAfterInserted;
    /// <summary>
    /// 해당 인벤토리에 아이템이 제거된 후 호출 (취소 불가능)<br/>
    /// 추가된 버전 : Indev 9
    /// </summary>
    public UnityEvent<InventoryInsertAndRemoveEventArgs> OnAfterRemoved;

    //public ItemEvent test;
    //test = EditorGUILayout.ObjectField(test, typeof(ItemEvent), false) as ItemEvent;
    //public UnityEditor.MonoScript test2;
    /// <summary>
    /// 아이템을 삽입 / 확인합니다<br/>
    /// C# 인덱서의 한계로 인해 tag는 normal로 고정되며,<br/>
    /// tag를 설정하려면 replaceItem() 메서드를 이용해야 합니다<br/>
    /// 추가된 버전 : Indev 9
    /// </summary>
    /// <param name="index">삽입할 아이템 슬롯</param>
    /// <returns>해당 슬롯에 삽입된 아이템</returns>
    public ItemStack this[int index]
    {
        get
        {
            return value[index];
        }
        set
        {
            InventoryInsertAndRemoveEventArgs e = new InventoryInsertAndRemoveEventArgs
            {
                FromInventory = null,
                FromInventoryIndex = -1,
                Handled = false,
                InsertedItem = value,
                ToInventory = this,
                ToInventoryIndex = index,
                tag = "normal"
            };
            OnBeforeInserted.Invoke(e);
            this.value[e.ToInventoryIndex] = e.InsertedItem;
            e = new InventoryInsertAndRemoveEventArgs
            {
                FromInventory = null,
                FromInventoryIndex = -1,
                Handled = false,
                InsertedItem = value,
                ToInventory = this,
                ToInventoryIndex = index,
                tag = "normal"
            };
            OnAfterInserted.Invoke(e);
        }
    }
    /// <summary>
    /// 아이템을 삽입하며, tag를 설정할 수 있습니다<br/>
    /// tag를 normal(기본값)으로 설정할 것이라면, [슬롯 번호] = 아이템 형식으로 대체할 수 있습니다<br/>
    /// 추가된 버전 : Indev 9
    /// </summary>
    /// <param name="index">삽입할 아이템 슬롯</param>
    /// <param name="item">삽입할 아이템</param>
    /// <param name="tag">이벤트에서 사용하는 tag (기본값 : normal)</param>
    public void replaceItem(int index, ItemStack item, string tag = "normal")
    {
        InventoryInsertAndRemoveEventArgs e = new InventoryInsertAndRemoveEventArgs
        {
            FromInventory = null,
            FromInventoryIndex = -1,
            Handled = false,
            InsertedItem = item,
            ToInventory = this,
            ToInventoryIndex = index,
            tag = tag
        };
        OnBeforeInserted.Invoke(e);
        value[e.ToInventoryIndex] = e.InsertedItem;
        e = new InventoryInsertAndRemoveEventArgs
        {
            FromInventory = null,
            FromInventoryIndex = -1,
            Handled = false,
            InsertedItem = item,
            ToInventory = this,
            ToInventoryIndex = index,
            tag = tag
        };
        OnAfterInserted.Invoke(e);
    }
    
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
    public int AddItem(ItemStack item, string tag = "normal")
    {
        void AfterEvent()
        {
            InventoryInsertAndRemoveEventArgs e = new InventoryInsertAndRemoveEventArgs
            {
                FromInventory = null,
                FromInventoryIndex = -1,
                Handled = false,
                InsertedItem = item,
                ToInventory = this,
                ToInventoryIndex = -1,
                tag = tag
            };
            OnAfterInserted.Invoke(e);
        }
        InventoryInsertAndRemoveEventArgs e = new InventoryInsertAndRemoveEventArgs
        { 
            FromInventory = null,
            FromInventoryIndex = -1,
            Handled = false,
            InsertedItem = item,
            ToInventory = this,
            ToInventoryIndex = -1,
            tag = tag
        };
        /*foreach (ItemEvent Event in Events)
        {
            Event.ItemInserted(ref e);
        }*/
        OnBeforeInserted.Invoke(e);
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
                AfterEvent();
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
                AfterEvent();
                return 0;
            }
        }
        AfterEvent();
        return item.count;
    }
    public void RemoveItem(int slot, int usedCnt, string tag = "normal")
    {
        InventoryInsertAndRemoveEventArgs e = new InventoryInsertAndRemoveEventArgs { FromInventory = null, FromInventoryIndex = -1, Handled = false, InsertedItem = value[slot], ToInventory = this, ToInventoryIndex = -1, tag = tag};
        OnBeforeRemoved.Invoke(e);
        if (e.Handled)
        {
            return;
        }
        value[slot].count -= usedCnt;
        if (value[slot].count <= 0)
        {
            value[slot].count = 0;
            value[slot].ItemID = -1;
        }
        e = new InventoryInsertAndRemoveEventArgs { FromInventory = null, FromInventoryIndex = -1, Handled = false, InsertedItem = value[slot], ToInventory = this, ToInventoryIndex = -1, tag = tag };
        OnAfterRemoved.Invoke(e);
    }
}
