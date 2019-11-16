using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterRippleForScreens;

public class EnemyDamageManager : MonoBehaviour
{
    private RippleEffect rippleEffect;
    public int health;
    public enum color { orange, blue, pink, white};
    public color enemyColor;
    private int damageMultiplier;
    public int damageBonusMultiplier = 3;
    public ScoreManager scoreManager;
    public SoundManager soundManager;
    public GameObject blueAura;
    public GameObject pinkAura;
    public GameObject yellowAura;

    public int scoreGainIfSameColor;
    public int scoreGainIfNotSameColor;


    private void Start()
    {
        rippleEffect = Camera.main.GetComponent<RippleEffect>();
        GameObject gameManager = GameObject.Find("GameManager");
        scoreManager = gameManager.GetComponent<ScoreManager>();
        soundManager = gameManager.GetComponent<SoundManager>();
        switch (enemyColor)
        {
            case color.orange:
                yellowAura.gameObject.SetActive(true);
                break;
            case color.blue:
                blueAura.gameObject.SetActive(true);
                break;
            case color.pink:
                pinkAura.gameObject.SetActive(true);
                break;
        }
    }
    void Update()
    {
        if (health <= 0)
        {
            //Afficher les Fx de destruction d'ennemis
            soundManager.soundDeathEnemy();
            Destroy(gameObject);
        }
    }

    public void ApplyDamage(int damageValue, color bulletColor)
    {
        Vector3 rippleEffectStart = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        rippleEffectStart = Camera.main.WorldToScreenPoint(rippleEffectStart);
        Vector2 rippleEffectStart2 = new Vector2(rippleEffectStart.x, rippleEffectStart.y);
        rippleEffect.SetNewRipplePosition(rippleEffectStart2);
        soundManager.soundImpact();
        if (bulletColor == enemyColor)
        {
            damageMultiplier = damageBonusMultiplier;
            scoreManager.IncrementScore(scoreGainIfSameColor);
        }
        else
        {
            damageMultiplier = 1;
            scoreManager.IncrementScore(scoreGainIfNotSameColor);
        }

        health -= damageValue * damageMultiplier;
        
    }

   
}
