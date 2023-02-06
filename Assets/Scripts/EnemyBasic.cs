using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    protected int health;
    public float screenBound = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}


//parent class for enemy types
//include hp etc vars
//attack manager game object attached - separate obj class
//this class will call various attack methods outlined in obj