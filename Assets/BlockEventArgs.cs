using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRightClickEventArgs
{
    /// <summary>
    /// �⺻ ��Ŭ�� ���� (�� ��ġ) ��� ����
    /// </summary>
    public bool Handled;
    /// <summary>
    /// �ش� ���
    /// </summary>
    public GameObject block;
    /// <summary>
    /// Ŭ���� ��
    /// </summary>
    public Vector3 side;
}
