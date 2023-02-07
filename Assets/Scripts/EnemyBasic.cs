using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    protected int health;
    public float screenBound = 20.0f; //oob for destroy
    protected float speed;
    protected List<Vector3> spawnLocs = new List<Vector3>();
    protected Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
        
        
        if (transform.position.x > screenBound || transform.position.x < -screenBound || transform.position.y > screenBound || transform.position.y < -screenBound)
        {
            Destroy(gameObject);
        }

        if (health == 0)
        {
            Destroy(gameObject);   
        }



    }

    
}


//parent class for enemy types
//include hp etc vars
//attack manager game object attached - separate obj class