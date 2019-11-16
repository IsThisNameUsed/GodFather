using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParameters : MonoBehaviour
{
    public EnemyDamageManager.color color;
    public float speed;
    public float lifeTime;
    public int damage;
    public bool enemyBullet;
    private SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.parent = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if(enemyBullet == false)
        //Destroy(this.gameObject, lifeTime);
        if (!sprite.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (enemyBullet == true && col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerDeathManager>().KillPlayer(); ;
        }

        if (enemyBullet  == false && col.gameObject.tag == "Enemy")
        {
            //appel ennemyDamageManager paramètre -> damage et color 

            if (col.gameObject.name == "Boss") {
                BossDamageManager bossDamageManager = col.gameObject.GetComponent<BossDamageManager>();
                bossDamageManager.ApplyDamage(damage, color);
            }
            else {
                EnemyDamageManager enemyDamageManager = col.gameObject.GetComponent<EnemyDamageManager>();
                enemyDamageManager.ApplyDamage(damage, color);
            }
            Destroy(gameObject);
        }
    }

}
