using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SeedOK : MonoBehaviour
{
    public GameObject TextInput;
    public void OK()
    {
        if (TextInput.GetComponent<Text>().text != "")
        {
            GameObject.Find("MapGenRNG").GetComponent<MapGenRNG>().SetSeed(int.Parse(TextInput.GetComponent<Text>().text));
        }
        SceneManager.LoadScene("MainScene");
    }
}
