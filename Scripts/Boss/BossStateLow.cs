using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateLow : MonoBehaviour
{
    // Boss State 1

    public GameObject boss;

    public GameObject Bullet;

    public GameObject[] straitSp;

    public GameObject[] circSpTop;
    public GameObject[] circSpBot;
    public GameObject[] circSpMid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator BossShoot() {
        for (int i=0; i<=29;i++) {
            int lenght = straitSp.Length;
            int j = Random.Range(0,lenght);
            GameObject Bubu = Instantiate (Bullet, straitSp[j].transform.position,straitSp[j].transform.rotation);
            Rigidbody2D BubuRb = Bubu.GetComponent<Rigidbody2D>();
            BubuRb.velocity = new Vector2(-0.2f,0) *8;
            yield return new WaitForSeconds(0.2f); 
        }
        boss.GetComponent<BossManager>().shootingStance = false;
        boss.GetComponent<BossManager>().startShooting = false;
        yield break;
    } 

    public IEnumerator BossShootCircular(){
        for (int i =0; i<=3; i++) {
            for(int j =0; j < circSpTop.Length; j++ ) {
                GameObject Bubu = Instantiate(Bullet, circSpTop[j].transform.position, circSpTop[j].transform.rotation);
                Rigidbody2D BubuRb = Bubu.GetComponent<Rigidbody2D>();
                BubuRb.velocity = new Vector2(-0.2f,0) *8;
            }

            for(int k =0; k < circSpBot.Length; k++ ) {
                GameObject Bubu = Instantiate(Bullet, circSpBot[k].transform.position, circSpBot[k].transform.rotation);
                Rigidbody2D BubuRb = Bubu.GetComponent<Rigidbody2D>();
                BubuRb.velocity = new Vector2(-0.2f,0) *8;
            }
            yield return new WaitForSeconds(0.75f);
            for(int l =0; l < circSpMid.Length; l++ ) {
                GameObject Bubu = Instantiate(Bullet, circSpMid[l].transform.position, circSpMid[l].transform.rotation);
                Rigidbody2D BubuRb = Bubu.GetComponent<Rigidbody2D>();
                BubuRb.velocity = new Vector2(-0.2f,0) *8;
            }
            yield return new WaitForSeconds(1.5f);
        }
        boss.GetComponent<BossManager>().shootingStance = false;
        boss.GetComponent<BossManager>().startShooting = false;
        yield break;
    }
}
