using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRightClick : MonoBehaviour
{
    public GameObject ChestGUIPrefab;
    public void OnRightClick(BlockRightClickEventArgs e)
    {
        e.Handled = true;
        GameObject gui = Instantiate(ChestGUIPrefab);
        gui.transform.parent = GameObject.Find("Canvas").transform;
        gui.transform.localPosition = Vector3.zero;
        foreach (ItemDisplay item in gui.GetComponentsInChildren<ItemDisplay>())
        {
            if (item.ItemSlotNumberOrOffset == 36)
            {
                item.Inventory = e.block.GetComponent<Inventory>();
            }
            else
            {
                item.Inventory = GameObject.Find("Capsule").GetComponent<Inventory>();
            }
        }
    }
}
