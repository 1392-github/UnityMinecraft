using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BlockData : MonoBehaviour
{
    public int BlockID;
    public int DropItem;
    public float BreakTime;
    //[HideInInspector]
    public float BreakTimeCurrent;
    public List<int> BreakSound;
    public List<int> PlaceSound;
    public UnityEvent<BlockRightClickEventArgs> OnRightClick;
    // Current Not Working
    public UnityEvent<BlockPlaceEventArgs> OnPlace;
    void Start()
    {
        //VisibleCheck();
    }
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
        GameObject.Find("Register").GetComponent<Register>().placedBlocks.Remove(gameObject);
        //foreach (GameObject b in GameObject.Find("Register").GetComponent<Register>().placedBlocks.ToArray())
        //{
        //    b.GetComponent<BlockData>().VisibleCheck();
        //}
        Destroy(gameObject);
    }
    // Not Working
    public void VisibleCheck()
    {
        bool[] flag = new bool[6];
        //GameObject[] blocks = GameObject.Find("Register").GetComponent<Register>().placedBlocks.ToArray();
        List<Transform> blocks = new List<Transform>();
        foreach (Transform child in transform.parent)
        {
            blocks.Add(child);
        }
        //GameObject[] blocks = transform.parent.GetEnumerator(.ToArray()

        foreach (Transform block in blocks)
        {
            //Debug.Log($"Block COMP ({block.transform.position}, {transform.position}");
            Vector3 vector = block.position - transform.position;
            //if (block.transform.position.x - transform.position.x <= 1)
            //{
            //    flag[0] = true;
            //}
            //else if (block.transform.position.x - transform.position.x >= -1)
            //{
            //    flag[1] = true;
            //}
            //else if (block.transform.position.y - transform.position.y <= 1)
            //{
            //    flag[2] = true;
            //}
            //else if (block.transform.position.y - transform.position.y >= -1)
            //{
            //    flag[3] = true;
            //}
            //else if (block.transform.position.z - transform.position.z <= 1)
            //{
            //    flag[4] = true;
            //}
            //else if (block.transform.position.z - transform.position.z >= -1)
            //{
            //    flag[5] = true;
            //}
            if (vector == new Vector3(1, 0, 0))
            {
                flag[0] = true;
            }
            else if (vector == new Vector3(-1, 0, 0))
            {
                flag[1] = true;
            }
            else if (vector == new Vector3(0, 1, 0))
            {
                flag[2] = true;
            }
            else if (vector == new Vector3(0, -1, 0))
            {
                flag[3] = true;
            }
            else if (vector == new Vector3(0, 0, 1))
            {
                flag[4] = true;
            }
            else if (vector == new Vector3(0, 0, -1))
            {
                flag[5] = true;
            }
            if (!flag.Contains(false))
            {
                break;
            }
        }
        Debug.Log(string.Join(", ", flag));
        gameObject.SetActive(flag.Contains(false));
    }
}
