using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
    public List<GameObject> blocks;
    public List<Item> items;
    public List<AudioClip> audioClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaceBlock(GameObject block, float x, float y, float z)
    {
        GameObject b = Instantiate(block);
        b.transform.position = new Vector3(x, y, z);
        BlockData data = b.GetComponent<BlockData>();
        GameObject.Find("Register").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("Register").GetComponent<Register>().audioClips[data.PlaceSound[Random.Range(0, data.PlaceSound.Count)]]);
    }
    public void PlaceBlock(GameObject block, Vector3 pos)
    {
        GameObject b = Instantiate(block);
        b.transform.position = pos;
        BlockData data = b.GetComponent<BlockData>();
        GameObject.Find("Register").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("Register").GetComponent<Register>().audioClips[data.PlaceSound[Random.Range(0, data.PlaceSound.Count)]]);
    }
    
}
