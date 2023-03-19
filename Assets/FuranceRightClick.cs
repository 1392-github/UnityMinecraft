using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuranceRightClick : MonoBehaviour
{
    public GameObject FuranceGUIPrefab;
    public void OnRightClick(BlockRightClickEventArgs e)
    {
        e.Handled = true;
        GameObject gui = Instantiate(FuranceGUIPrefab);
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
