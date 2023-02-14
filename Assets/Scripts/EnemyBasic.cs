using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public int health;
    public float screenBound = 20.0f; //oob for destroy
    protected float speed;
    protected List<Vector3> spawnLocs = new List<Vector3>();
    protected Rigidbody rb;
    public GameObject pla;


    // Start is called before the first frame update
    void Start()
    {

        pla = GameObject.FindGameObjectWithTag("Player");
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

    //hp decrement 
    //contact /w player = delete
    protected void OnTriggerEnter(Collider other)
    {
        //health--;
        if (other.gameObject.tag == "PlayerAttack")
        {
            health--;
            Destroy(other.gameObject); //dest laser
        }
        
    }




}


//parent class for enemy types
//include hp etc vars
//attack manager game object attached - separate obj class