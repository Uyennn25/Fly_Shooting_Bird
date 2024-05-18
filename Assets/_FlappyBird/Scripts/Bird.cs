using System;
using GameTool;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private float jumpForce = 10f;
    private float cooldown = 0.5f;
    private float spawndelay;
    [SerializeField] private Rigidbody2D rb;

   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawndelay = cooldown;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0f, jumpForce);
        }
        

        if (spawndelay <= 0)
        {
            spawndelay = cooldown;
            //sinh dan
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet,null,transform.position);
        }
        else
        {
            spawndelay -= Time.deltaTime;
        }
    }
}
