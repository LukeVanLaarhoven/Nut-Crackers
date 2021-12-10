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

    public GameObject bulletPrefab;
    private GameObject bullet;

    List<GameObject> bulletList = new List<GameObject>();

    public void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();

        initialRateOfFire = rateOfFire;
    }

    private void Update()
    {
        //Debug.Log(playerMovement.currentAimingPoint.position.x);
        //Debug.Log(playerMovement.currentAimingPoint.position.y);

        //barrel.transform.position = playerMovement.currentAimingPoint.position;
    }

    public void Shoot()
    {
        rateOfFire -= Time.deltaTime;

        if (Input.GetButton("Fire1") && rateOfFire < 0)
        {
            Debug.Log("Shoot");

            bullet = Instantiate(bulletPrefab, playerMovement.currentAimingPoint.position, CalculateBulletSpread(weaponSpread));
            bulletList.Add(bullet);

            rateOfFire = initialRateOfFire;
        }

        for (int i = 0; i < bulletList.Count; i++)
        {
            bulletList[i].transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);
        }

        StartCoroutine(RemoveBullet(bullet, destroyTimer));
    }

    private IEnumerator RemoveBullet(GameObject bullet, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        bulletList.Remove(bullet);

        Destroy(bullet);
    }

    private Quaternion CalculateBulletSpread(float weaponSpread)
    {
        Quaternion angle = Quaternion.Euler(0, 0, playerMovement.currentAimingPoint.eulerAngles.z + Random.Range(-weaponSpread, weaponSpread));

        return angle;
    }
}
