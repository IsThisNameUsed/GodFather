using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSinus : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawner;
    public GameObject Bullet;

    public bool StartShoot = false;
    public bool isShooting = false;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StartShoot) {
            StartCoroutine(AutoDestruct());
            StartCoroutine(ShootTheBullet());
            isShooting = true;
            StartShoot = false;
        }
    }

    private IEnumerator ShootTheBullet() {
        while(isShooting) {
            GameObject Bubu = Instantiate(Bullet, spawner.transform.position, Quaternion.identity);
            Rigidbody2D bubuRB = Bubu.GetComponent<Rigidbody2D>();
            bubuRB.velocity = new Vector2(-0.2f,0) *8;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator AutoDestruct() {
        yield return new WaitForSeconds(15f);
        isShooting = false;
    }
}
