using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInsertAndRemoveEventArgs
{
    /// <summary>
    /// �κ��丮 ������ ����/������ ����� �� ����
    /// </summary>
    public bool Handled;
    /// <summary>
    /// �ٸ� �κ��丮 ĭ���� �������� �̵��� ��� ��� ĭ�� �ִ� Inventory, �ƴ� ��� null
    /// </summary>
    public Inventory FromInventory;
    /// <summary>
    /// ������ ������ �Ͼ�� Inventory
    /// </summary>
    public Inventory ToInventory;
    /// <summary>
    /// �ٸ� �κ��丮 ĭ���� �������� �̵��� ��� ��� ĭ ��ȣ, �ƴ� ��� -1
    /// </summary>
    public int FromInventoryIndex;
    /// <summary>
    /// ������ ����/������ �Ͼ�� ĭ ��ȣ
    /// </summary>
    public int ToInventoryIndex;
    /// <summary>
    /// ����/������ ������
    /// </summary>
    public ItemStack InsertedItem;
}
