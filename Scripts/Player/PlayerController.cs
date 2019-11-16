using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private float speedSlow;

    public GameObject HitBox;

    public GameObject[] shooters;
    public Transform[] shooterTransform;
    public float playerBulletSpeed = 2;

    private GameObject actualBullet;
    public GameObject bulletWhite;
    public GameObject bulletPink;
    public GameObject bulletBlue;
    public GameObject bulletOrange;

    public GameObject character;
    public Sprite avant;
    public Sprite arrière;


    private PlayerDeathManager playerDeathManager;
    private SoundManager soundManager;
    public int color;

    public GameObject PauseMenu;
    public bool PauseTime = false;

    public GameObject boss;
    public GameObject Score; // pos mid x:519; y: 216
    public GameObject textWin;
    public Image textWinBackground;
    private bool checkBoss;


   void Awake(){
       textWin .SetActive(false);
       checkBoss = true;
   }
   
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameObject gameManager = GameObject.Find("GameManager");
        soundManager = gameManager.GetComponent<SoundManager>();
        playerDeathManager = GetComponent<PlayerDeathManager>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        color = 0;
        actualBullet = bulletWhite;
        speedSlow = speed / 3;

        for(int i = 0; i<=4;i++)
        {
            shooterTransform[i] = shooters[i].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeScale);
        Debug.Log(checkBoss);
        if (Input.GetKeyDown("joystick button 0"))
        {
            speed = speedSlow;
            HitBox.SetActive(true);
        }

        if (Input.GetKeyUp("joystick button 0"))
        {
            speed = speedSlow * 3;
            HitBox.SetActive(false);
        }

        if (playerDeathManager.isDead == false)
        {
            Shoot();
            Movement();
        }

        if (Input.GetKeyDown("c") || Input.GetKeyDown("joystick button 7")) {
            if (!PauseTime) {
                Time.timeScale = 0;
                PauseTime = true;
                PauseMenu.SetActive(true);
            }
            else if (PauseTime){
                Time.timeScale = 1;
                PauseTime = false;
                PauseMenu.SetActive(false);
            }
        }
        if (checkBoss) {
            if (boss.GetComponent<BossDamageManager>().health <= 0) {
                StartCoroutine(Endgame());
                checkBoss = false;
            }
        }
    }

    public void Movement()
    {
        Vector3 movement = new Vector3((Input.GetAxisRaw("MoveHorizontal")), (Input.GetAxisRaw("MoveVertical")), 0.0f);

        //transform.position = transform.position + movement * Time.deltaTime * speed;
        rb.velocity = new Vector2(movement.x, movement.y) * speed;

        if(Input.GetAxisRaw("MoveHorizontal") < 0 && PauseTime == false)
        {
            character.GetComponent<SpriteRenderer>().sprite = arrière;
        }

        else
        {
            character.GetComponent<SpriteRenderer>().sprite = avant;
        }
    }

    public void Shoot()
    {

        //shooter[0] = shooter1.transform;

        if (Input.GetButtonDown("Fire"))
        {
            if (color == 0)
                actualBullet = bulletWhite;
            else if (color == 1)
            {
                //Debug.Log("pinkBullet");
                actualBullet = bulletPink;
            }
            else if (color == 2)
            {
                //Debug.Log("blueBullet");
                actualBullet = bulletBlue;
            }
            else if (color == 3)
            {
                //Debug.Log("orangeBullet");
                actualBullet = bulletOrange;
            }
            Shoot(actualBullet);
        }
    }

    public void ModifyColor(int newColor)
    {
        // 0->White 1->pink 2->blue 3->orange
        color = newColor;
    }

    public void Shoot(GameObject bullet)
    {
        if (color == 1 || color == 0)
            SoloShoot(bullet);
        else if (color == 2)
            BlueShoot(bullet);
        else if (color == 3)
            OrangeShoot(bullet);

        //GameObject obj = Instantiate(bullet, shooter1);
        //obj.transform.parent = Camera.main.transform;
    }

    private void SoloShoot(GameObject bullet)
    {
        soundManager.soundTir1();
        GameObject obj = Instantiate(bullet, shooterTransform[2].position, Quaternion.identity);
        obj.transform.parent = Camera.main.transform;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.velocity = shooterTransform[2].right * playerBulletSpeed;
    }

    private void BlueShoot(GameObject bullet)
    {
        soundManager.soundTir2();
        for (int i=1;i<=3;i++)
        {
            GameObject obj = Instantiate(bullet, shooterTransform[i].position, Quaternion.identity);
            obj.transform.parent = Camera.main.transform;
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.velocity = shooterTransform[i].right * playerBulletSpeed;
        }
        
    }

    private void OrangeShoot(GameObject bullet)
    {
        soundManager.soundTir3();
        for (int i = 0; i <= 4; i++)
        {
            GameObject obj = Instantiate(bullet, shooterTransform[i].position, Quaternion.identity);
            obj.transform.parent = Camera.main.transform;
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.velocity = shooterTransform[i].right * playerBulletSpeed;
        }
    }

    private IEnumerator Endgame() {
        textWin.SetActive(true);
        Score.transform.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        Score.transform.localScale = new Vector2(1,1);
        yield return new WaitForSeconds(7.5f);
        SceneManager.LoadScene("Menu");
        yield break;
    }
}
