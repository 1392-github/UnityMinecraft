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
        Destroy(gameObject);
    }
}
