using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int type = 0;
    public float time = 0;
    public float shotTime = 0;
    public int hp = 3;
    public float stopTime = 1;
    public float resumeTime = 3;
    public float speed = 4;
    public bool timeToShoot = false;
    public GameObject explosion;

    public GameObject enemyShot;
    public float maxShotTime;
    public float shotSpeed;
    void Start()
    {
        switch(type)
        {
            case 0:
                hp = 10;
                maxShotTime = 0.45f;
                shotSpeed = 6;
                speed = 5.5f;
                break;
            case 1:
                hp = 20;
                speed = 8.4f;
                maxShotTime = 0;
                shotSpeed = 5;
                break;
            case 2:
                hp = 40;
                speed = 5.3f;
                maxShotTime = 0.45f;
                shotSpeed = 8;
                break;
            case 3:
                hp = 400;
                speed = 5.3f;
                break;
        }
    }

    public int GetHP()
    {
        return this.hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(type == 0 || type == 2)
        {
            time += Time.deltaTime;
            if(time < stopTime || time > resumeTime)
            {
                timeToShoot = false;
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                shotTime += Time.deltaTime;
                if (shotTime > maxShotTime)
                {
                    shotTime = 0;
                    GameObject enemy = Instantiate(enemyShot, transform.position, Quaternion.identity);
                    EnemyShotScript enemyShotScript = enemy.GetComponent<EnemyShotScript>();
                    enemyShotScript.speed = shotSpeed;
                }
                timeToShoot = true;
            }
        } 
        else
        {
            timeToShoot = true;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
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

    private void OnBecameInvisible()
    {
        if(type != 3)
        {
            Destroy(gameObject);
        }
    }

    void bossPattern()
    {

    }
}
