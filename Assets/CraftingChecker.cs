using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingChecker : MonoBehaviour
{
    Register register;
    Inventory craftingInventory;
    // Start is called before the first frame update
    void Start()
    {
        register = GameObject.Find("Register").GetComponent<Register>();
        craftingInventory = gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        bool flag = false;
        foreach (ShapedCrafting shaped in register.shapedCrafting)
        {
            int[] items = Enumerable.Repeat(-1, 9).ToArray();
            items[0] = craftingInventory.value[0].ItemID;
            items[1] = craftingInventory.value[1].ItemID;
            items[3] = craftingInventory.value[2].ItemID;
            items[4] = craftingInventory.value[3].ItemID;
            int[] crafting = new int[9];
            for (int i = 0; i < 9; i++)
            {
                if (shaped.recipeStr[i] == ' ')
                {
                    crafting[i] = -1;
                }
                else
                {
                    //Debug.Log($"IND = {System.Convert.ToInt32(shaped.recipeStr[i].ToString())}, {i}");
                    //Debug.Log($"recipestr = {string.Join(", ", shaped.charItem)}");
                    crafting[i] = shaped.charItem[System.Convert.ToInt32(shaped.recipeStr[i].ToString())];
                }
            }
            //Debug.Log($"CRAFTCHK items = {string.Join(", ", items)}, crafting = {string.Join(", ", crafting)}");
            if (Enumerable.SequenceEqual(items, crafting))
            {
                craftingInventory.value[4] = shaped.resultItem.Copy();
                flag = true;
                return;
            }
        }
        foreach (ShapeLessCrafting shapeless in register.shapeLessCrafting)
        {
            int[] items = Enumerable.Repeat(-1, 9).ToArray();
            items[0] = craftingInventory.value[0].ItemID;
            items[1] = craftingInventory.value[1].ItemID;
            items[3] = craftingInventory.value[2].ItemID;
            items[4] = craftingInventory.value[3].ItemID;
            flag = true;
            foreach (int item in shapeless.items)
            {
                if (!(craftingInventory.value.Select(i => i.ItemID).Contains(item)))
                {
                    flag = false;
                }
            }
            foreach (int item in items)
            {
                if (!shapeless.items.Contains(item) && item != -1)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                craftingInventory.value[4] = shapeless.resultItem.Copy();
                return;
            }
        }
        if (flag == false)
        {
            craftingInventory.value[4] = new ItemStack(-1, 0);
        }
    }
}
