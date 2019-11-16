using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{
    
    public Vector2 position;
    private Transform playerSprite;
    private Transform shooters;
    public GameObject player;
    public CameraShaker camShaker;
    private SoundManager soundManager;
    private ScoreManager scoreManager;

    [Tooltip("Time of invicibility after player's respawn ")]
    public float invicibiltyDuration = 2;
    public bool isInvicible;
    private float countTimeOfInvicibility;
    public float delayBeforeRespawn;
    private float countTimeBeforeRespawn;
    public bool isDead;
    private bool firstFrameOfDeath = false;
    public Animation invicibilityAanimation;
    public GameObject playerExplosion;

    private GameObject[] Bullets;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        playerSprite = transform.Find("Player");
        shooters = transform.Find("Shooters");
        position = player.transform.position;
        camShaker = Camera.main.GetComponent<CameraShaker>();
        countTimeBeforeRespawn = delayBeforeRespawn;
        countTimeOfInvicibility = invicibiltyDuration;
    }

    void FixedUpdate() {
        Bullets = GameObject.FindGameObjectsWithTag("bullets");
    }
    public void Update()
    {
        //Bullets.Add(FindGameObjectsWithTag("bullets"));
        if(isDead == true)
        {
            //On arrête le shake de caméra après une seconde
            playerExplosion.gameObject.SetActive(true);
            if (delayBeforeRespawn - countTimeBeforeRespawn > 1)
                camShaker.SetShake(false);

            if (countTimeBeforeRespawn>0)
                countTimeBeforeRespawn -= Time.deltaTime;
            else
            {
                countTimeBeforeRespawn = delayBeforeRespawn;
                playerSprite.gameObject.SetActive(true);
                shooters.gameObject.SetActive(true);
                isDead = false;
                isInvicible = true;
            }
            for (int i= 0; i < Bullets.Length; i++) {
                Destroy(Bullets[i].gameObject);
            }
        }

        if(isDead == false)
        {
            playerExplosion.gameObject.SetActive(false);
        }

        if(isInvicible == true)
        {
            invicibilityAanimation.Play();
            countTimeOfInvicibility -= Time.deltaTime;
            if (countTimeOfInvicibility < 0)
            {
                isInvicible = false;
                invicibilityAanimation.Stop();
                countTimeOfInvicibility = invicibiltyDuration;
            }
        }
    }
    // Update is called once per frame
    public void KillPlayer()
    {
        if (isInvicible) return;
        scoreManager.IncrementScore(-50000);
        camShaker.SetShake(true);
        playerSprite.gameObject.SetActive(false);
        shooters.gameObject.SetActive(false);
        isDead = true;
        soundManager.soundDeathPlayer();
    }
}
