using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2 : BossManager
{
    // Récupération des données de vie du Boss
    public GameObject boss;
    private float bossCurrentHealth;
    public float bossMidHealth;
    private float bossFullHealth;

    // Lancer le marqueur
    public bool markerStart; 
    public GameObject markerBegin;
    public GameObject markerGoal;
    public float speed = 100f;

    // Le laser en tant que tel
    public GameObject megaLaser;
    private GameObject laser;
    private bool laserScale;

    

    void Awake() {
        markerStart = false;
        bossFullHealth = boss.GetComponent<BossDamageManager>().health;
        bossMidHealth = bossFullHealth / 2;

        megaLaser.transform.localScale = new Vector3(1,1,0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate() {
        bossCurrentHealth = boss.GetComponent<BossDamageManager>().health;
    }

    // Update is called once per frame
    void Update() {
    
    }
}
