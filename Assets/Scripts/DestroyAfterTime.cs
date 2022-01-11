using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float destroyTimer = .5f;
    float lastTime;

    private void Start()
    {
        lastTime = Time.realtimeSinceStartup + destroyTimer;
    }

    // Update is called once per frame
    void Update()
    {
        // If time is greater than the final time, set disabled
        if (Time.realtimeSinceStartup >= lastTime)
        {
            gameObject.SetActive(false);
        }
    }
}
