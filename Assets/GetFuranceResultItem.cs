using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetFuranceResultItem : ItemEvent
{
    public void Event(InventoryInsertAndRemoveEventArgs e)
    {
        Debug.Log("ItemRemoved");
        Debug.Log($"ToInventory : {e.ToInventoryIndex}");
        if (e.ToInventoryIndex != 2) // 결과 창이 아니면
        {
            return;
        }
        e.ToInventory.RemoveItem(0, 1);
        e.ToInventory.RemoveItem(1, 1);
    }
}
