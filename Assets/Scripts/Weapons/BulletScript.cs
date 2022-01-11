using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
