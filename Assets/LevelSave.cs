using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// 현재 개발 중인 기능입니다
public class LevelSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FileStream fs =
            new FileStream("c:\\users\\noname\\downloads\\minecraft_map.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            int fpos = 0;
            List<GameObject> blocks = GameObject.Find("Register").GetComponent<Register>().placedBlocks;
            foreach (GameObject b in blocks)
            {
                BlockData bd = b.GetComponent<BlockData>();
                bw.Write(new byte[] { System.Convert.ToByte(b.transform.position.x), System.Convert.ToByte(b.transform.position.y), System.Convert.ToByte(b.transform.position.z), System.Convert.ToByte(bd.BlockID)});

            }
            bw.Close();
            fs.Close();
        }
    }
}
