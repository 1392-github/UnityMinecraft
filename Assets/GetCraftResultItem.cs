using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2x2 제작 창에서 결과 아이템을 꺼냈을 때 제작 창의 다른 아이템을 제거하는 ItemEvent
/// </summary>
public class GetCraftResultItem : ItemEvent
{
    public void Event(InventoryInsertAndRemoveEventArgs e)
    {
        Debug.Log("ItemRemoved");
        Debug.Log($"ToInventory : {e.ToInventoryIndex}");
        if (e.ToInventoryIndex != 4) // 결과 창이 아니면
        {
            return;
        }
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("a");
            e.ToInventory.RemoveItem(i, 1);
        }
    }
}
