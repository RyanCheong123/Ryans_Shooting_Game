using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBgScript : MonoBehaviour
{
    float speed = 0.7f;
    SpriteRenderer spr;
    public GameManager gm;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gm.bossOn)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            Vector3 pos = transform.position;
            if (pos.x + spr.bounds.size.x / 2 < -8)
            {
                pos.x += spr.bounds.size.x * 3;
                transform.position = pos;
            }
        }

    }
}
