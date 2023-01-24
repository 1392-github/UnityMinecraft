using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    Rigidbody rigid;
    public float MoveSpeed;
    public float JumpPower;
    public float RotateSpeed;
    List<GameObject> blockRegister;
    public Text PosX;
    public Text PosY;
    public Text PosZ;
    public Text Seed;
    public ItemStack[] inventory = Enumerable.Repeat(new ItemStack(-1, 0), 36).ToArray(); // 모두 (-1,0)으로 초기화
    public int SelectedSlot = 0;
    // Start is called before the first frame update
    void Start()
    {
        blockRegister = GameObject.Find("Register").GetComponent<Register>().blocks;
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
    Vector3 GetAxisSide(Vector3 point) {
        float [] axiss = new float[3];
        axiss[0] = point.x;
        axiss[1] = point.y;
        axiss[2] = point.z;
        int largeNumIndex = 0;

        for (int i = 1; i < 3; i++) {
            //절댓값이 가장 큰 축을 찾는다
            if (Mathf.Abs(axiss[largeNumIndex]) < Mathf.Abs(axiss[i]))
                largeNumIndex = i;
        }

        switch (largeNumIndex) {
            //x축이 가장 절댓값이 크다면
            case 0:
                point.y = 0;
                point.z = 0;
                //x축이 양수라면
                if (axiss[largeNumIndex] > 0)
                    point.x = 1;
                else
                    point.x = -1;
                return point;
            //y축이 가장 절댓값이 크다면
            case 1:
                point.x = 0;
                point.z = 0;
                //y축이 양수라면
                if (axiss[largeNumIndex] > 0)
                    point.y = 1;
                else
                    point.y = -1;
                return point;
            //z축이 가장 절댓값이 크다면
            case 2:
                point.x = 0;
                point.y = 0;
                //z축이 양수라면
                if (axiss[largeNumIndex] > 0)
                    point.z = 1;
                else
                    point.z = -1;
                return point;
            default:
                Debug.Log("축 절댓값 인덱스가 잘못되었습니다");
                return Vector3.zero;
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
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 5))
                {
                    hit.collider.gameObject.GetComponent<BlockData>().DestroyBlock();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 5))
                {
                    Vector3 axisSide = GetAxisSide(hit.transform.position - ray.GetPoint(hit.distance));
                    Vector3 blockPos = hit.transform.position - axisSide;
                    Debug.Log(blockPos);
                    if (GetComponent<Inventory>().value[SelectedSlot].ItemID != -1)
                    {
                        
                        GameObject.Find("Register").GetComponent<Register>().PlaceBlock(blockRegister[GetComponent<Inventory>().value[SelectedSlot].GetItem().placedBlockID], blockPos);
                        GetComponent<Inventory>().RemoveItem(SelectedSlot, 1);
                    }
                }
            }
        }
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
        if (Input.GetKey("e"))
        {
            GameObject.Find("Canvas").transform.Find("Inventory").gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SelectedSlot = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SelectedSlot = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SelectedSlot = 2;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            SelectedSlot = 3;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            SelectedSlot = 4;
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            SelectedSlot = 5;
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            SelectedSlot = 6;
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            SelectedSlot = 7;
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            SelectedSlot = 8;
        }
        
    }
}