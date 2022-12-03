using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    float x = 0;
    float y = 8;
    float z = 0;
    /*public GameObject stonePrefab;
    public GameObject grassBlockPrefab;
    public GameObject dirtPrefab;
    public GameObject bedrockPrefab;
    public GameObject ironOrePrefab;
    public GameObject diamondOrePrefab;*/
    public MapGenRNG RNG;
    public int MapSize;
    public int Height;
    List<GameObject> blockRegister;
    // Start is called before the first frame update
    void Genererate1Chunk(float x, float z)
    {
        for (float bx = x; bx < x + 16; bx += 1)
        {
            for (float bz = z; bz < z + 16; bz += 1)
            {
                GameObject grass_block = Instantiate(blockRegister[0]);
                GameObject dirt1 = Instantiate(blockRegister[1]);
                GameObject dirt2 = Instantiate(blockRegister[1]);
                for (int i = 61; i > 1; i--)
                {
                    int BlockRate = RNG.IntRandom(0, 100); // 0 ~ 99
                    GameObject block;
                    if (BlockRate == 0) // 1%
                    {
                        block = Instantiate(blockRegister[5]);
                    }
                    else if (BlockRate < 6) // 5% 
                    {
                        block = Instantiate(blockRegister[4]);
                    }
                    else // 94%
                    {
                        block = Instantiate(blockRegister[2]);
                    }
                    block.transform.position = new Vector3(bx, i, bz);
                }
                GameObject bedrock = Instantiate(blockRegister[3]);
                grass_block.transform.position = new Vector3(bx, 64, bz);
                dirt1.transform.position = new Vector3(bx, 63, bz);
                dirt2.transform.position = new Vector3(bx, 62, bz);
                bedrock.transform.position = new Vector3(bx, 1, bz);
                
                
            }
        }
    }
    void Start()
    {
        RNG = GameObject.Find("MapGenRNG").GetComponent<MapGenRNG>();
        blockRegister = GameObject.Find("Register").GetComponent<Register>().blocks;
        MapSize = RNG.mapSize;
        for (int x = -MapSize * 16; x <= MapSize * 16; x += 16)
        {
            for (int z = -MapSize * 16; z <= MapSize * 16; z += 16)
            {
                //Debug.Log($"x = {x}, z = {z}");
                Genererate1Chunk(x, z); 
            }       
        }
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
