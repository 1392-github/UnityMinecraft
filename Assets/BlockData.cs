using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockData : MonoBehaviour
{
    public int BlockID;
    public int DropItem;
    public List<int> BreakSound;
    public List<int> PlaceSound;
    public void DestroyBlock()
    {
        GameObject.Find("Register").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("Register").GetComponent<Register>().audioClips[BreakSound[Random.Range(0, BreakSound.Count)]]);
        Inventory inv = GameObject.Find("Capsule").GetComponent<Inventory>();
        /*int i;
        bool flag = false;
        for (i = 0; i < 36; i++)
        {
            if ((inv.value[i].ItemID == -1) || (inv.value[i].ItemID == DropItem && inv.value[i].count < 64))
            {
                flag = true;
                break;
            }
        }
        if (flag && DropItem != -1)
        {
            Debug.Log(i);
            if (inv.value[i].ItemID == -1)
            {
                inv.value[i].ItemID = DropItem;
                inv.value[i].count = 1;
            }
            else
            {
                inv.value[i].count += 1;
            }
        }*/
        inv.AddItem(new ItemStack(DropItem, 1));
        Destroy(gameObject);
    }
}
