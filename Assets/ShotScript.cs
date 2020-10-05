using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public GameObject shotEffect;
    public float speed = 10;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            AsteroidScript asteroidScript = collision.gameObject.GetComponent<AsteroidScript>();
            asteroidScript.hp -= 10;
            Instantiate(shotEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (asteroidScript.hp <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                GameManager.instance.score += 10;
                GameManager.instance.scoreText.text = GameManager.instance.score.ToString();
            }
        }
        if (collision.tag == "Enemy")
        {
            EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            enemyScript.hp -= 10;
            Instantiate(shotEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (enemyScript.hp <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                GameManager.instance.score += 30;
                GameManager.instance.scoreText.text = GameManager.instance.score.ToString();
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
