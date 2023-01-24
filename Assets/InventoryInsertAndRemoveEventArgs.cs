using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInsertAndRemoveEventArgs
{
    /// <summary>
    /// 인벤토리 아이템 삽입/삭제를 취소할 지 여부
    /// </summary>
    public bool Handled;
    /// <summary>
    /// 다른 인벤토리 칸에서 아이템이 이동된 경우 출발 칸이 있는 Inventory, 아닌 경우 null
    /// </summary>
    public Inventory FromInventory;
    /// <summary>
    /// 아이템 삽입이 일어나는 Inventory
    /// </summary>
    public Inventory ToInventory;
    /// <summary>
    /// 다른 인벤토리 칸에서 아이템이 이동된 경우 출발 칸 번호, 아닌 경우 -1
    /// </summary>
    public int FromInventoryIndex;
    /// <summary>
    /// 아이템 삽입/삭제가 일어나는 칸 번호
    /// </summary>
    public int ToInventoryIndex;
    /// <summary>
    /// 삽입/삭제된 아이템
    /// </summary>
    public ItemStack InsertedItem;
}
