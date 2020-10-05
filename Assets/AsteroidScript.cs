using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotSpeed = 45;
    public float speed = 4;
    public int hp = 10;
    public GameObject explosion;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotSpeed));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AsteroidScript asteroidScript = collision.gameObject.GetComponent<AsteroidScript>();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
