using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public void ItemInserted(ref InventoryInsertAndRemoveEventArgs e) { }
    public void ItemRemoved(ref InventoryInsertAndRemoveEventArgs e) { }
}
