using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private float initialRateOfFire;
    public float rateOfFire;
    public float weaponSpread;
    public float bulletSpeed;
    public float destroyTimer;
    public AudioSource shootAudio;

    public GameObject bulletPrefab;
    private GameObject bullet;

    public BulletScript bs;

    public void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();

        initialRateOfFire = rateOfFire;
    }

    public void Shoot()
    {
        rateOfFire -= Time.deltaTime;

        if (rateOfFire < 0)
        {
            bs.speed = bulletSpeed;

            bullet = Instantiate(bulletPrefab, playerMovement.currentAimingPoint.position, CalculateBulletSpread(weaponSpread));

            shootAudio.Play();

            rateOfFire = initialRateOfFire;
        }
    }

    private Quaternion CalculateBulletSpread(float weaponSpread)
    {
        Quaternion angle = Quaternion.Euler(0, 0, playerMovement.currentAimingPoint.eulerAngles.z + Random.Range(-weaponSpread, weaponSpread));

        return angle;
    }
}
