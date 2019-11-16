using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMedium : MonoBehaviour
{
    // Boss State 2
    public GameObject boss;

    public GameObject circSpawner;
    public GameObject bulletSp;
    public GameObject[] straitSpawner;
    public GameObject SinusSp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator BossShoot() {
        for (int i =0; i < straitSpawner.Length;i++) {
            straitSpawner[i].GetComponent<BulletSinus>().StartShoot = true;
        }
        yield return new WaitForSeconds(4f);
        boss.GetComponent<BossManager>().shootingStance = false;
        boss.GetComponent<BossManager>().startShooting = false;
        yield break;
    } 

    public IEnumerator BossShootCircular(){
        circSpawner.GetComponent<BulletRafale>().StartShoot = true;
        yield return new WaitForSeconds(2);
        boss.GetComponent<BossManager>().shootingStance = false;
        boss.GetComponent<BossManager>().startShooting = false;
        yield break;
    }
}
