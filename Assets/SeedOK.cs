using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SeedOK : MonoBehaviour
{
    public GameObject TextInput;
    public GameObject MapSizeInput;
    public void OK()
    {
        if (TextInput.GetComponent<Text>().text != "")
        {
            try
            {
                GameObject.Find("MapGenRNG").GetComponent<MapGenRNG>().SetSeed(int.Parse(TextInput.GetComponent<Text>().text));
            }
            catch (System.Exception)
            {
                
                GameObject.Find("MapGenRNG").GetComponent<MapGenRNG>().SetSeed(TextInput.GetComponent<Text>().text.GetHashCode());
            }
        }
        if (MapSizeInput.GetComponent<Text>().text != "")
        {
            GameObject.Find("MapGenRNG").GetComponent<MapGenRNG>().mapSize = int.Parse(MapSizeInput.GetComponent<Text>().text);
            SceneManager.LoadScene("MainScene");
        }
    }
}
