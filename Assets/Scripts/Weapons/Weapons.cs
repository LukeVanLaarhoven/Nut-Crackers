using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    private float initialRateOfFire;
    public float rateOfFire;
    public float weaponSpread;
    public float bulletSpeed;

    public GameObject barrel;
    public GameObject bulletPrefab;
    private GameObject bullet;

    List<GameObject> bulletList = new List<GameObject>();

    public void Start()
    {
        initialRateOfFire = rateOfFire;
    }

    public void Shoot()
    {
        rateOfFire -= Time.deltaTime;

        if (Input.GetButton("Fire1") && rateOfFire < 0)
        {
            Debug.Log("Shoot");

            bullet = Instantiate(bulletPrefab, barrel.transform.position, CalculateBulletSpread(weaponSpread));
            bulletList.Add(bullet);

            rateOfFire = initialRateOfFire;
        }

        for (int i = 0; i < bulletList.Count; i++)
        {
            bulletList[i].transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);
        }

        Destroy(bullet, 5);

        if(bullet == null)
        {
            bulletList.Remove(bullet);
        }

        Debug.Log(bulletList.Count);
    }

    private Quaternion CalculateBulletSpread(float weaponSpread)
    {
        Quaternion angle = Quaternion.Euler(0, 0, Random.Range(-weaponSpread, weaponSpread));

        return angle;
    }
}
