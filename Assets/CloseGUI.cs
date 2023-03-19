using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGUI : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
    }
}
