using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // System.Random�� UnityEngine.Random ȥ�� ����

public class Register : MonoBehaviour
{
    public List<GameObject> blocks;
    public List<Item> items;
    public List<AudioClip> audioClips;
    public List<Texture> itemTextures;
    public List<ShapedCrafting> shapedCrafting;
    public List<ShapeLessCrafting> shapeLessCrafting;
    public List<GameObject> placedBlocks;
    public List<GameObject> placedChunks;
    // Start is called before the first frame update
    void Start()
    {
        //items = new List<Item>();
        //items.Add(new Item(0, 64, 1));
        //items.Add(new Item(1, 64, 2));
        //items.Add(new Item(2, 64, 4));
        //items.Add(new Item(3, 64, 5));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaceBlock(int block, float x, float y, float z, bool disableSound = false)
    {
        GameObject b = Instantiate(blocks[block]);
        b.transform.position = new Vector3(x, y, z);
        BlockData data = b.GetComponent<BlockData>();
        if (!disableSound)
        {
            GameObject.Find("Register").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("Register").GetComponent<Register>().audioClips[data.PlaceSound[Random.Range(0, data.PlaceSound.Count)]]);
        }
        placedBlocks.Add(b);
    }
    public void PlaceBlock(GameObject block, Vector3 pos)
    {
        GameObject b = Instantiate(block);
        b.transform.position = pos;
        BlockData data = b.GetComponent<BlockData>();
        GameObject.Find("Register").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("Register").GetComponent<Register>().audioClips[data.PlaceSound[Random.Range(0, data.PlaceSound.Count)]]);
        placedBlocks.Add(b);
    }
    /// <summary>
    /// ���忡 ���� ��ġ�մϴ�
    /// </summary>
    /// <param name="block">��ġ�� ���� ���� ID</param>
    /// <param name="x">��ġ�� ���� x��ǥ</param>
    /// <param name="y">��ġ�� ���� y��ǥ</param>
    /// <param name="z">��ġ�� ���� z��ǥ</param>
    /// <param name="disableSound">�� ��ġ ȿ������ ���� ���� (true = ����, false = ����)</param>

    // Temp Disabled
    //public void PlaceBlock(int block, float x, float y, float z, bool disableSound = false)
    //{
    //    GameObject b = Instantiate(blocks[block]);
    //    Vector3 pos = new Vector3(x, y, z);
    //    Vector3 chpos = new Vector3(Convert.ToInt32(x)/4, Convert.ToInt32(y) /4, Convert.ToInt32(z) / 4);
    //    Vector3 bpos = new Vector3(Convert.ToInt32(x)%4, Convert.ToInt32(y)%4, Convert.ToInt32(z)%4);
    //    GameObject chunk = null;
    //    foreach (GameObject c in placedChunks)
    //    {
    //        if (c.transform.position == chpos * 4)
    //        {
    //            chunk = c;
    //        }
    //    }
    //    if (chunk == null)
    //    {
    //        chunk = new GameObject($"Chunk{Random.Range(0, 1000000)}");
    //        chunk.transform.position = chpos * 4;
    //        placedChunks.Add(chunk);
    //    }
    //    b.transform.parent = chunk.transform;
    //    b.transform.localPosition = bpos;
    //    BlockData data = b.GetComponent<BlockData>();
    //    if (!disableSound)
    //    {
    //        GameObject.Find("Register").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("Register").GetComponent<Register>().audioClips[data.PlaceSound[Random.Range(0, data.PlaceSound.Count)]]);
    //    }
    //    placedBlocks.Add(b);
    //}
    //public void PlaceBlock(int block, Vector3 pos, bool disableSound = false)
    //{
    //    GameObject b = Instantiate(blocks[block]);
    //    Vector3 chpos = new Vector3(Convert.ToInt32(pos.x) / 4, Convert.ToInt32(pos.y) / 4, Convert.ToInt32(pos.z) / 4);
    //    Vector3 bpos = new Vector3(Convert.ToInt32(pos.x) % 4, Convert.ToInt32(pos.y) % 4, Convert.ToInt32(pos.z) % 4);
    //    GameObject chunk = null;
    //    foreach (GameObject c in placedChunks)
    //    {
    //        if (c.transform.position == chpos * 4)
    //        {
    //            chunk = c;
    //        }
    //    }
    //    if (chunk == null)
    //    {
    //        chunk = new GameObject($"Chunk{Random.Range(0, 1000000)}");
    //        chunk.transform.position = chpos;
    //        placedChunks.Add(chunk);
    //    }
    //    b.transform.parent = chunk.transform;
    //    b.transform.localPosition = bpos;
    //    b.transform.position = pos;
    //    BlockData data = b.GetComponent<BlockData>();
    //    if (!disableSound)
    //    {
    //        GameObject.Find("Register").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("Register").GetComponent<Register>().audioClips[data.PlaceSound[Random.Range(0, data.PlaceSound.Count)]]);
    //    }
    //    placedBlocks.Add(b);
    //}
    /// <summary>
    /// ���忡 ���� ��ġ�մϴ�
    /// </summary>
    /// <param name="block">��ġ�� ���� ���� ID</param>
    /// <param name="pos">��ġ�� ���� ��ǥ</param>
    /// <param name="disableSound">�� ��ġ ȿ������ ���� ���� (true = ����, false = ����)</param>
    public void PlaceBlock(int block, Vector3 pos, bool disableSound = false)
    {
        PlaceBlock(block, pos.x, pos.y, pos.z, disableSound);
    }
}
