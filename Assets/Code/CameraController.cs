using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //Camera.main.fieldOfView = 250;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z));
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(-RotateSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(RotateSpeed, 0, 0);
        }
    }
}
