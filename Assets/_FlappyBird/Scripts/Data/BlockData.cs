using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockData", menuName = "Block Data")]
public class BlockData : ScriptableObject
{
    public List<BlockInfo> BlockInfos;
}
[Serializable]
public class BlockInfo
{
    public BlockType blockType;
    public float maxHP;
    public List<Sprite> status;

}

public enum BlockType
{
    Wood = 0,
    Stone = 1,
    Metal = 2,
}
