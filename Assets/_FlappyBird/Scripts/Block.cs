using GameTool;
using UnityEngine;

public class Block : BasePooling
{
   public SpriteRenderer sr;
   public BoxCollider2D coll;
   public BlockType blockType;
   public float curHP;
   public float maxHP;
   public void setData()
   {
      maxHP = GameData.Instance.blockData.BlockInfos[(int)blockType].maxHP;
      curHP = maxHP;
      sr.sprite = GameData.Instance.blockData.BlockInfos[(int)blockType].status[2];
   }

   public void TakeDamage(float damage)
   {
      curHP -= damage;
      if (curHP < 0)
      {
         Destroy(gameObject);
         GameData.Instance.score += 1;
         if (GameData.Instance.score > GameData.Instance.HightScore)
         {
            GameData.Instance.HightScore = GameData.Instance.score;
            GameMenu.Instance.UpdateHightScoreText(GameData.Instance.score); 
         }
         GameMenu.Instance.UpdateScoreText(GameData.Instance.score);
      }
      setSprite();
   }

   public void setSprite()
   {
      if (curHP / maxHP > 2f/3)
      {
         sr.sprite = GameData.Instance.blockData.BlockInfos[(int)blockType].status[2]; 
      }
      else if (curHP / maxHP > 1f/3)
      {
         sr.sprite = GameData.Instance.blockData.BlockInfos[(int)blockType].status[1];
      }
      else if(curHP / maxHP > 0)
      {
         sr.sprite = GameData.Instance.blockData.BlockInfos[(int)blockType].status[0];
      }
   }
}
