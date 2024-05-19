using System;
using GameTool;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wall : BasePooling
{
    private float speed = 5f;
    private int min = 1;
    private int max = 4;
    private float bound;
    private int blockNumber = 4;

    private void OnEnable()
    {
        bound = Camera.main.orthographicSize;
        CreateBlock();
    }

    private void CreateBlock()
    {
        float[] height = new float [blockNumber];
        height[0] = Random.Range(min, max);
        height[1] = bound - height[0];
        height[2] = Random.Range(min, max);
        height[3] = bound - height[2];

        float[] posy = new float [blockNumber];
        posy[0] = bound - height[0] / 2;
        posy[1] = height[1] / 2;
        posy[2] = -height[2] / 2;
        posy[3] = -bound + height[3] / 2;

        for (int i = 0; i < blockNumber; i++)
        {
            BlockType blockType = (BlockType)Random.Range(0, 3);
            var block = (Block)PoolingManager.Instance.GetObject(NamePrefabPool.Block, transform,
                new Vector2(transform.position.x,posy[i]));
            block.blockType = blockType;
            block.setData();
            block.sr.size = new Vector2(block.sr.size.x, height[i]);
            block.coll.size = block.sr.size;
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
