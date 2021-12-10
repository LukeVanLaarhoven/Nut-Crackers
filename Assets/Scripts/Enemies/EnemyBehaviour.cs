using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject bullet;

    [Space(10)]
    public Transform barrelEnd;

    [Space(10)]
    public float minTime;
    public float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {
        Shoot();
    }

    void Shoot()
    {
        Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
    }

    public float CalculateDelayTime()
    {
        float randomDelay;
        randomDelay = Random.Range(minTime, maxTime);

        return randomDelay;
    }

    private IEnumerator DelayShoot(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Shoot();
    }
}
