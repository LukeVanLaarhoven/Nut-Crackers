using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float rateOfFire;
    public float weaponSpread;
    public float bulletSpeed;

    public GameObject barrel;
    private GameObject bulletPrefab;

    public void Shoot()
    {
        if (Input.GetButton("Fire1") && rateOfFire < 0)
        {
            print("Shoot");
        }
    }

    private void CalculateBulletSpread()
    {
        Quaternion angle = Quaternion.Euler(0, 0, weaponSpread);
    }
}
