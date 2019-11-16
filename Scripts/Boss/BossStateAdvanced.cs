using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateAdvanced : MonoBehaviour
{
    // Boss State 3
    public GameObject boss;

    public GameObject[] circSpawner;
    public Vector2[] circVector;
    public GameObject[] straitSpawner;
    public Vector2[] straitVector; 
    public GameObject Bullet;
    public float speedBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i=0; i++ < circSpawner.Length;) {
            circVector[i] = circSpawner[i].transform.position;
        }

        for (int i=0; i++ < straitSpawner.Length;) {
            straitVector[i] = straitSpawner[i].transform.position;
        }*/
    }

    public IEnumerator BossShoot() {
        Debug.Log("Start fonction Straight");
        for (int i =0; i <=9;i++) {
            for (int j=0; j < straitSpawner.Length; j++) {
                if (j <= 3) {
                    GameObject Bubu = Instantiate(Bullet, straitSpawner[j].transform.position, straitSpawner[j].transform.rotation);
                    Rigidbody2D bubuRB = Bubu.GetComponent<Rigidbody2D>();
                    bubuRB.velocity = new Vector2(0,-0.2f) * 8;
                    yield return new WaitForSeconds(0.05f);
                    Debug.Log("Tir Droit rapide");
                }
                else if (j >= 4) {
                    GameObject Bubu = Instantiate(Bullet, straitSpawner[j].transform.position, straitSpawner[j].transform.rotation);
                    Rigidbody2D bubuRB = Bubu.GetComponent<Rigidbody2D>();
                    bubuRB.velocity = new Vector2(0, 0.2f) * 8;
                    yield return new WaitForSeconds(0.05f);
                    Debug.Log("Tir Droit rapide");
                }
            }
        }
        boss.GetComponent<BossManager>().shootingStance = false;
        boss.GetComponent<BossManager>().startShooting = false;
        yield break;
    } 

    public IEnumerator BossShootCircular(){
        Debug.Log("Startshoot");
        for (int i =0 ; i <= 9;i++) {
            for (int j=0; j < circSpawner.Length; j++) {
                if (j<= 3) {
                    GameObject Bubu = Instantiate(Bullet, circSpawner[j].transform.position, circSpawner[j].transform.rotation);
                    Rigidbody2D bubuRB = Bubu.GetComponent<Rigidbody2D>();
                    bubuRB.velocity = new Vector2(-0.2f, -0.2f) * 8;
                    yield return new WaitForSeconds(0.02f);
                    Debug.Log("Tir Circular Rapide");
                }
                else if (j >= 4) {
                    GameObject Bubu = Instantiate(Bullet, circSpawner[j].transform.position, circSpawner[j].transform.rotation);
                    Rigidbody2D bubuRB = Bubu.GetComponent<Rigidbody2D>();
                    bubuRB.velocity = new Vector2(-0.2f, 0.2f) * 8;
                    yield return new WaitForSeconds(0.02f);
                    Debug.Log("Tir Circular Rapide");
                }
            }
        }
        yield return new WaitForSeconds(0.5f);
        boss.GetComponent<BossManager>().shootingStance = false;
        boss.GetComponent<BossManager>().startShooting = false;
        yield break;
    }
}
