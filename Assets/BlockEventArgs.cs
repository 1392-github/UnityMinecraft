using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRightClickEventArgs
{
    /// <summary>
    /// 기본 우클릭 동작 (블럭 설치) 취소 여부
    /// </summary>
    public bool Handled;
    /// <summary>
    /// 해당 블록
    /// </summary>
    public GameObject block;
    /// <summary>
    /// 클릭된 면
    /// </summary>
    public Vector3 side;
}
