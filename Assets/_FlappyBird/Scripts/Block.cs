using GameTool;
using UnityEngine;

public class Block : BasePooling
{
   public SpriteRenderer sr;
   public BoxCollider2D coll;
   public BlockType blockType;
   public float curHP;

   public void setData()
   {
      curHP = GameData.Instance.blockData.BlockInfos[(int)blockType].maxHP;
      sr.sprite = GameData.Instance.blockData.BlockInfos[(int)blockType].status[2];
   }
}
