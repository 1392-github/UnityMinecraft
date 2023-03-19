using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FuranceCheck : MonoBehaviour
{
    public void Check(InventoryInsertAndRemoveEventArgs e)
    {
        if (e.tag == "furance_insert")
        {
            return;
        }
        if (!(GameObject.Find("Register").GetComponent<Register>().furanceFuelItems.Contains(e.ToInventory[1].ItemID))) // 연료 아이템이 없으면
        {
            e.ToInventory.replaceItem(2, ItemStack.Empty, "furance_insert");
            return;
        }
        foreach (FuranceRecipe recipe in GameObject.Find("Register").GetComponent<Register>().furanceRecipes)
        {
            if (recipe.FromItem == e.ToInventory[0].ItemID)
            {
                e.ToInventory.replaceItem(2, new ItemStack(recipe.ToItem, 1), "furance_insert");
                return;
            }
        }
        e.ToInventory.replaceItem(2, ItemStack.Empty, "furance_insert");
    }
}
