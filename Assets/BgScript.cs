using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    float speed = 2;
    SpriteRenderer spr;
    public GameManager gm;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gm.bossOn)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            Vector3 pos = transform.position;
            if (pos.x + spr.bounds.size.x / 2 < -8)
            {
                float size = spr.bounds.size.x * 2;
                pos.x += size;
                transform.position = pos;
            }
        }
    }
}
