using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    // Script in charge of the Boss Behavior

    // For the Color Swapping
    public int newColor;                                        

    // If the ColorSwapping must be timed. Change this value on the Inspector (in second)
    public float timerChange;                                   
    private float timerState;
    public bool timerGo;                                        // timerGo is for stopping the Timer for any reason.

    // Control the Boss Color.
    private SpriteRenderer spriteBoss;                          
    //public Color[] bossState;                                   // The array can be modify through the Inspector. No need to change the code.
    public GameObject[] bossPhase;
    public int phase;

    // Bullet Type
    // public GameObject[] Bullets;                              // Pour les Instantiate des bullets. Un type de balle par type de tir (Straight, Circular);                              
    public bool isShooting;                                  // Timer entre les tirs du boss.
    public float timerShoot;
    public float cooldownShoot;
    public bool shootingStance;
    public bool startShooting;
    public bool endDialog;


    // FLASH!
    public GameObject Flash;

    private bool followPlayer = false;
    private Rigidbody2D bossRB;

    public GameObject Camera;

    private DialogSequences dialogSequences;
    void Awake()
    {
        // Set the Color changing mechanics
        newColor = 0;
        timerState =  0;
        timerGo = true;

        // Set the automatic shooter mechanics
        timerShoot = 0;
        shootingStance = false;
        startShooting = false;
        endDialog = false;

        bossRB = this.GetComponent<Rigidbody2D>();
    }

    void Start () {

        dialogSequences = GameObject.Find("GameManager").GetComponent<DialogSequences>();
        // Set the first phase of the boss (currently on the second one)
        spriteBoss = this.GetComponent<SpriteRenderer>();
        //spriteBoss.color = bossState[1];
        phase = 1;
    }
    
    void FixedUpdate () {

        
    }

    // Update is called once per frame
    void Update()
    {
       // State change with a Timer
        if (endDialog) {        
            if (timerGo) {
                timerState += Time.deltaTime;
            }
        }

        if (timerState >= timerChange) {
            Debug.Log("I need to change my Phase");
            newColor = Random.Range(0,3);                   // choose 1 color in the Array (state 1 = Array[0] and state 4 = Array[3])
            //spriteBoss.color = bossState[newColor];
            while (phase == newColor) {
                newColor = Random.Range(0,3);
            }
            phase = newColor;
                
            timerState = 0;
        }


        // Shoot stance activation
        if (endDialog) {
            if (!shootingStance && !startShooting) {
                timerShoot += Time.deltaTime;
            }
        }
        if (shootingStance && !startShooting) {
            int whatToShoot = Random.Range(1,3);
            startShooting = true;

            if (whatToShoot == 1) {
                if (phase == 0) {
                    // Active le Tir Direct de la Phase 1

                    StartCoroutine (bossPhase[phase].GetComponent<BossStateLow>().BossShoot());
                    Debug.Log("I shoot straight in phase 1");
                }

                else if (phase == 1) {
                    // Active le tir direct de la phase 2

                    StartCoroutine (bossPhase[phase].GetComponent<BossStateMedium>().BossShoot());
                    Debug.Log("I shoot straight in phase 2");
                }

                else if (phase == 2) {
                    // active le tir direct de la phase 3

                    StartCoroutine (bossPhase[phase].GetComponent<BossStateAdvanced>().BossShoot());
                    Debug.Log("I shoot straight in phase 3");
                }
            }

            else if(whatToShoot == 2) {
                if (phase == 0) {
                    // active le tir circulaire de la phase 1

                    StartCoroutine (bossPhase[phase].GetComponent<BossStateLow>().BossShootCircular());
                    Debug.Log("I shoot in circles in phase 1");
                }

                else if (phase == 1) {
                    // active le tir circulaire de la phase 2

                    StartCoroutine (bossPhase[phase].GetComponent<BossStateMedium>().BossShootCircular());
                    Debug.Log("I shoot in circles in phase 2");
                }

                else if (phase == 2) {
                    // active le tir circulaire de la phase 3

                    StartCoroutine (bossPhase[phase].GetComponent<BossStateAdvanced>().BossShootCircular());
                    Debug.Log("I shoot in circles in phase 3");
                }
            }
        }

        if(timerShoot >= cooldownShoot) {
            shootingStance = true;
            timerShoot = 0;
        }

        
        // Testing tools

        /*if (Input.GetKeyDown("a")) {
            newColor = Random.Range(0,4);                   // choose 1 color in the Array (state 1 = Array[0] and state 4 = Array[3])
            spriteBoss.color = bossState[newColor];
        }*/
        /*
        if (Input.GetKeyDown("r")) {
            StartCoroutine(bossPhase[1].GetComponent<BossStateMedium>().BossShootCircular());

        }

        if (Input.GetKeyDown("a")) {
            StartCoroutine(bossPhase[1].GetComponent<BossStateMedium>().BossShoot());

        }

        if (Input.GetKeyDown("s")) {
            Flash.GetComponent<FlashScreen>().Flashbang();
        }
        if (Input.GetKeyDown("m")) {
            StartCoroutine(bossPhase[2].GetComponent<BossStateAdvanced>().BossShootCircular());
        }
        if (Input.GetKeyDown("l")) {
            StartCoroutine(bossPhase[2].GetComponent<BossStateAdvanced>().BossShoot());
            
        }
        if (Input.GetKeyDown("n")) {
            StartCoroutine(bossPhase[0].GetComponent<BossStateLow>().BossShootCircular());
            
        }
        if (Input.GetKeyDown("b")) {
            StartCoroutine(bossPhase[0].GetComponent<BossStateLow>().BossShoot());
        }*/

        if (followPlayer)
        {
            //Debug.Log("Je bouge");
            // bossRB.velocity = new Vector2(5f, 0);
            this.transform.parent = Camera.transform;
        }
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        //Debug.Log("Coucou je bouge");
        if (other.gameObject.CompareTag("bossCollid"))
        {
            Debug.Log("coucou");
            followPlayer = true;
            dialogSequences.LaunchDialogBoss();
            endDialog = true;
            //StartCoroutine(EndDialog());
        }
    }

    public IEnumerator EndDialog() {
        yield return new WaitForSeconds(10f);
        endDialog = true;
        yield break;
    }
}
