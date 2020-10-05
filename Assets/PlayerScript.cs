using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;
    Vector3 min, max;
    Vector2 colSize;
    Vector2 chrSize;
    public GameObject shot;
    public Transform shotPointTr;
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        colSize = GetComponent<BoxCollider2D>().size;
        chrSize = new Vector2(colSize.x / 2, colSize.y / 2);
    }

    void Update()
    {
        Move();
        PlayerShot();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0).normalized;
        transform.position = transform.position + dir * Time.deltaTime * speed;
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (newX < min.x + chrSize.x)
        {
            newX = min.x + chrSize.x;
        }

        if (newX > max.x - chrSize.x)
        {
            newX = max.x - chrSize.x;
        }

        if (newY < min.y + chrSize.y)
        {
            newY = min.y + chrSize.y;
        }

        if (newY > max.y - chrSize.y)
        {
            newY = max.y - chrSize.y;
        }
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    public float shotMax = 0.5f;
    public float shotDelay = 0;
    void PlayerShot()
    {
        shotDelay += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space))
        {
            if(shotDelay > shotMax)
            {
                shotDelay = 0;
                Vector3 vec = new Vector3(transform.position.x + 0.6f, transform.position.y + 0.29f, transform.position.z);
                Instantiate(shot, vec, Quaternion.identity);
            }
        }
    }
}
