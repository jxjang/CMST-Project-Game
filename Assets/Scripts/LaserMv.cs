using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMv : MonoBehaviour
{

    public float speed = 30.0f;
    public float limit = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > limit)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    
}
