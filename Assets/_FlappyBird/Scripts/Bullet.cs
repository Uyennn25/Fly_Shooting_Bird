using System;
using GameTool;
using UnityEditor.UIElements;
using UnityEditorInternal;
using UnityEngine;

public class Bullet : BasePooling
{
   [SerializeField] private Rigidbody2D rb;
   [SerializeField] private SpriteRenderer sr;
   private float speed = 8f;
   public float  damage= 1f;
   private void OnEnable()
   {
       transform.localScale = 2*Vector3.one;
       rb.velocity = new Vector2(speed, 0f);
       
       var score = GameData.Instance.score;
       var index = score / 10;

       sr.sprite = GameData.Instance.bulletData.sprites[index];
       damage = GameData.Instance.bulletData.damage[index];
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
     if (other.gameObject.CompareTag("Block"))
      {
        var block = other.gameObject.GetComponent<Block>();
         block.TakeDamage(damage);
      gameObject.SetActive(false);
    }
   }
}
