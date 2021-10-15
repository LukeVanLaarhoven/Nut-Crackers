using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    private float rateOfFire;
    private float weaponSpread;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            print("Shoot");
        }
    }
}
