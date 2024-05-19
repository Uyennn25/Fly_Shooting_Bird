using GameTool;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private float jumpForce = 10f;
    private float cooldown = 0.5f;
    private float spawndelay;
    private float boundTop = 4.2f;
    private float boundBot = -4.3f;
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

        if (transform.position.y >= boundTop)
        {
            transform.position = new Vector3(transform.position.x, boundTop, transform.position.z);
        }
        
        if (transform.position.y <= boundBot)
        {
            transform.position = new Vector3(transform.position.x, boundBot, transform.position.z);
        }

        if (spawndelay <= 0)
        {
            spawndelay = cooldown;
            //sinh dan
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet,null,transform.position).Disable(1.25f);
        }
        else
        {
            spawndelay -= Time.deltaTime;
        }
    }
}
