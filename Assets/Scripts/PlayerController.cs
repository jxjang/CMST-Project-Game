using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float hzInput; //neg z
    public float vertInput; //y axis
    public float speed = 10.0f;
    //public float moveLimitz = -11.0f; //20L -20 R
    public float moveLimit = 11.0f; //norm
    public GameObject projectile; //attack prefab
    public int playerHP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //limit move block
        if ( transform.position.x < -moveLimit ) // leftlim
        {
            transform.position = new Vector3(-moveLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > moveLimit) //rightlim
        {
            transform.position = new Vector3(moveLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.y > moveLimit) //upperlim
        {
            transform.position = new Vector3(transform.position.x, moveLimit, transform.position.z);
        }
        else if (transform.position.y < -moveLimit) //lowerlim
        {
            transform.position = new Vector3(transform.position.x, -moveLimit, transform.position.z);
        }


        hzInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * hzInput * Time.deltaTime * -speed);
        transform.Translate(Vector3.up * vertInput * speed * Time.deltaTime);

        //attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }

    }
}

//player locked to bounds of screen
//wasd / arrow keys control
//add fire button - add delay .2-.3s

