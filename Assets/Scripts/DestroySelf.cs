using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private float timer = 0.0f;

    public float timeToDestroy = 1f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
