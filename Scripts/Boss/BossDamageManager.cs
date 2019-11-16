using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageManager : MonoBehaviour
{
    public int health;
    public enum color { orange, blue, pink, white};

    public GameObject boss;
    public EnemyDamageManager.color bossCurrentColor;

    private int damageMultiplier;
    public int damageBonusMultiplier = 3;
    public SpriteRenderer sprite;
    public ScoreManager scoreManager;

    public GameObject blueAura;
    public GameObject pinkAura;
    public GameObject yellowAura;

    public int scoreGainIfSameColor;
    public int scoreGainIfNotSameColor;

    void Awake() {
        
    }

    private void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() {
        if (boss.GetComponent<BossManager>().phase == 0) {
            bossCurrentColor = EnemyDamageManager.color.orange;
        }
        else if (boss.GetComponent<BossManager>().phase == 1) {
            bossCurrentColor = EnemyDamageManager.color.blue;
        }
        else if (boss.GetComponent<BossManager>().phase == 2) {
                bossCurrentColor = EnemyDamageManager.color.pink;
        }

        if (health <= 0)
        {
            Debug.Log("PAN je suis mort");
            //Afficher les Fx de destruction d'ennemis
            Destroy(this.gameObject);
        }
    }


    void Update()
    {
        switch(bossCurrentColor) {
            case EnemyDamageManager.color.orange:
                // sprite.color = Color.yellow;
                yellowAura.gameObject.SetActive(true);
                pinkAura.gameObject.SetActive(false);
                blueAura.gameObject.SetActive(false);
                break;
            case EnemyDamageManager.color.blue:
                // sprite.color = Color.blue;
                yellowAura.gameObject.SetActive(false);
                pinkAura.gameObject.SetActive(false);
                blueAura.gameObject.SetActive(true);
                break;
            case EnemyDamageManager.color.pink:
                // sprite.color = Color.magenta;
                yellowAura.gameObject.SetActive(false);
                pinkAura.gameObject.SetActive(true);
                blueAura.gameObject.SetActive(false);
                break;
        }

        
    }

    public void ApplyDamage(int damageValue, EnemyDamageManager.color bulletColor)
    {
        if (bulletColor == bossCurrentColor)
        {
            Debug.Log("HELLOOOOOO");
            damageMultiplier = damageBonusMultiplier;
            scoreManager.IncrementScore(scoreGainIfSameColor);
        }
        else
        {
            damageMultiplier = 1;
            scoreManager.IncrementScore(scoreGainIfNotSameColor);
        }

        health -= damageValue * damageMultiplier;
        Debug.Log(health);
    }
}
