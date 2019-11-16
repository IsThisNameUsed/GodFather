using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public float circularSpeed;
    public GameObject EnemyBullet;
    public enum shotType { straight, circular, towardsPlayer };
    public shotType typeOfShot;
    public Vector2 direction;
    Rigidbody2D rb;
    Camera cam;
    private bool fireOn;
    private bool hasBeenActivated;

    IEnumerator EnemyFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            //direction = direction + new Vector2(0, 0.1f);
            GameObject bullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
            bullet.transform.parent = Camera.main.transform;
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = direction * 3;
        }
    }

    IEnumerator EnemyCircularFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 8; i++)
            {
                GameObject bullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
                bullet.transform.parent = Camera.main.transform;
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                switch (i)
                {
                    case 0:
                        bulletRb.velocity = new Vector2(0.4f, 0) * circularSpeed;
                        break;
                    case 1:
                        bulletRb.velocity = new Vector2(-0.4f, 0) * circularSpeed;
                        break;
                    case 2:
                        bulletRb.velocity = new Vector2(0.2f, 0.2f) * circularSpeed;
                        break;
                    case 3:
                        bulletRb.velocity = new Vector2(-0.2f, 0.2f) * circularSpeed;
                        break;
                    case 4:
                        bulletRb.velocity = new Vector2(0.2f, -0.2f) * circularSpeed;
                        break;
                    case 5:
                        bulletRb.velocity = new Vector2(-0.2f, -0.2f) * circularSpeed;
                        break;
                    case 6:
                        bulletRb.velocity = new Vector2(0, 0.4f) * circularSpeed;
                        break;
                    case 7:
                        bulletRb.velocity = new Vector2(0, -0.4f) * circularSpeed;
                        break;
                }
            }
        }
    }

    IEnumerator EnemyFireTowardsPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            //direction = direction + new Vector2(0, 0.1f);
            //Debug.Log("shot toward player");
            Vector2 enemyPosition = transform.position;
            Vector2 playerPosition = player.transform.position;
            //direction = new Vector2(playerPosition.x - enemyPosition.y);
            direction = playerPosition - enemyPosition;
            GameObject bullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = direction * 1;
        }
    }


    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        fireOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.WorldToScreenPoint(transform.position).x < cam.pixelWidth + 10 && fireOn == false)
        {
            if (typeOfShot == shotType.circular) StartCoroutine("EnemyCircularFire");
            if(typeOfShot == shotType.straight) StartCoroutine("EnemyFire");
            if (typeOfShot == shotType.towardsPlayer) StartCoroutine("EnemyFireTowardsPlayer");
            fireOn = true;
        }
    }
}