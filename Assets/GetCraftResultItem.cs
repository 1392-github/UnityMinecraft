using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2x2 ���� â���� ��� �������� ������ �� ���� â�� �ٸ� �������� �����ϴ� ItemEvent
/// </summary>
public class GetCraftResultItem : ItemEvent
{
    public void Event(InventoryInsertAndRemoveEventArgs e)
    {
        Debug.Log("ItemRemoved");
        Debug.Log($"ToInventory : {e.ToInventoryIndex}");
        if (e.ToInventoryIndex != 4) // ��� â�� �ƴϸ�
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
