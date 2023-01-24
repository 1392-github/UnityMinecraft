using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Inventory Inventory;
    public int ItemSlotNumberOrOffset;
    public bool AutoDetect;
    [HideInInspector]
    public ItemDisplay moving;
    RawImage texture;
    Text cnt;
    //int slotNumber;
    List<Texture> textures;
    public GameObject moveItem;
    [HideInInspector]
    public bool MovingThisSlot;
    public bool IsMovingSlot;
    public int ActualSlotNumber
    {
        get { 
        if (AutoDetect)
        {
            return gameObject.transform.GetSiblingIndex() - ItemSlotNumberOrOffset;
        }
        else
        {
            return ItemSlotNumberOrOffset;
        } }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        textures = GameObject.Find("Register").GetComponent<Register>().itemTextures;
        texture = GetComponent<RawImage>();
        cnt = transform.Find("ItemCnt").gameObject.GetComponent<Text>();
        if (IsMovingSlot)
        {
            Destroy(transform.Find("ButtonHitBox").gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        if (IsMovingSlot)
        {
            // 화면 높이의 절반 구하기 
            float screenHeightHalf = Camera.main.orthographicSize; 

            // 화면 넓이의 절반 구하기 
            float screenWidthHalf = screenHeightHalf * Camera.main.aspect; 
            //Debug.Log($"{screenHeightHalf}, {screenWidthHalf}");

            // 오브젝트 이동 
            
            //float x = -screenWidthHalf; 
            //float y = -screenHeightHalf;
            float x = -960; 
            float y = -540;
            x += Input.mousePosition.x;
            y += Input.mousePosition.y;
            transform.localPosition = new Vector3(x, y, 0);
        }
        //Debug.Log($"{slotNumber}, {gameObject.name}");w
        if (Inventory.value[ActualSlotNumber].ItemID == -1 || MovingThisSlot)
        {
            texture.enabled = false;
            cnt.text = "";
        }
        else
        {
            texture.enabled = true;
            texture.texture = textures[Inventory.value[ActualSlotNumber].ItemID];
            cnt.text = Inventory.value[ActualSlotNumber].count.ToString();
        }
    }
    public void Clicked()
    {
        //Debug.Log($"Click Method Called : {ActualSlotNumber}");
        if (IsMovingSlot)
        {
            return;
        }
        if (moveItem.activeSelf)
        {
            if (Inventory.ReadOnlySlot.Contains(ActualSlotNumber))
            {
                //Debug.Log("This slot is Cannot insert item");
                return;
            }
            //Debug.Log("Moving Item : true");
            InventoryInsertAndRemoveEventArgs e = new InventoryInsertAndRemoveEventArgs { FromInventory = moveItem.GetComponent<ItemDisplay>().Inventory, FromInventoryIndex = moveItem.GetComponent<ItemDisplay>().ActualSlotNumber, Handled = false, InsertedItem = moveItem.GetComponent<ItemDisplay>().Inventory.value[moveItem.GetComponent<ItemDisplay>().ActualSlotNumber], ToInventory = Inventory, ToInventoryIndex = ActualSlotNumber };
            //foreach (ItemEvent Event in Inventory.Events)
            //{
            //    Debug.Log("InsertEvent");
            //    Event.ItemInserted(ref e);
            //}
            Inventory.OnInserted.Invoke(e);
            if (e.Handled)
            {
                return;
            }
            Inventory.value[ActualSlotNumber] = moveItem.GetComponent<ItemDisplay>().Inventory.value[moveItem.GetComponent<ItemDisplay>().ActualSlotNumber];
            e = new InventoryInsertAndRemoveEventArgs { FromInventory = null, FromInventoryIndex = -1, Handled = false, InsertedItem = moveItem.GetComponent<ItemDisplay>().Inventory.value[moveItem.GetComponent<ItemDisplay>().ActualSlotNumber], ToInventory = moveItem.GetComponent<ItemDisplay>().Inventory, ToInventoryIndex = moveItem.GetComponent<ItemDisplay>().ActualSlotNumber };
            Debug.Log("RemovedItem2");

            //foreach (ItemEvent Event in Inventory.Events)
            //{
            //    Debug.Log("RemoveEvent");
            //    Event.ItemRemoved(ref e);
            //}
            moveItem.GetComponent<ItemDisplay>().Inventory.OnRemoved.Invoke(e);
            if (e.Handled)
            {
                return;
            }
            moveItem.GetComponent<ItemDisplay>().Inventory.value[moveItem.GetComponent<ItemDisplay>().moving.ActualSlotNumber] = new ItemStack(-1, 0);
            moveItem.GetComponent<ItemDisplay>().moving.MovingThisSlot = false;
            moveItem.SetActive(false);
        }
        else
        {
            if (Inventory.value[ActualSlotNumber].ItemID == -1) 
            {
                Debug.Log("Empty");
                return;
            }
            Debug.Log("Moving Item : false");
            moveItem.SetActive(true);
            moveItem.GetComponent<ItemDisplay>().ItemSlotNumberOrOffset = ActualSlotNumber;
            moveItem.GetComponent<ItemDisplay>().Inventory = Inventory;
            moveItem.GetComponent<ItemDisplay>().moving = this;
            MovingThisSlot = true;
        }
    }
}
