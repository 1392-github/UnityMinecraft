using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    Rigidbody rigid;
    public float MoveSpeed;
    public float JumpPower;
    public float RotateSpeed;
    public Text PosX;
    public Text PosY;
    public Text PosZ;
    public Text Seed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        if (GameObject.Find("MapGenRNG").GetComponent<MapGenRNG>().seed == null)
        {
            Seed.text = "seed = Random Seed";
        }
        else
        {
            Seed.text = $"seed = {GameObject.Find("MapGenRNG").GetComponent<MapGenRNG>().seed}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        PosX.text = $"x = {transform.position.x}";
        PosY.text = $"y = {transform.position.y}";
        PosZ.text = $"z = {transform.position.z}";
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        /*if (Input.GetMouseButtonDown(2))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5))
            {
                hit.
            }
        }*/
        if (Input.GetKey("w"))
        {
            rigid.velocity = transform.rotation * Vector3.forward * MoveSpeed;
        }
        if (Input.GetKey("s"))
        {
            rigid.velocity = transform.rotation * Vector3.back * MoveSpeed;
        }
        if (Input.GetKey("a"))
        {
            rigid.velocity = transform.rotation * Vector3.left * MoveSpeed;
        }
        if (Input.GetKey("d"))
        {
            rigid.velocity = transform.rotation * Vector3.right * MoveSpeed;
        }
        if (Input.GetKey("space"))
        {
            if (rigid.velocity.y == 0.0f)
            {
                rigid.AddForce(0, JumpPower, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -RotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, RotateSpeed, 0);
        }
    }
}
