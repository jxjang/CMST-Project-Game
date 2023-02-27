using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    //single bullet behavior

    private float speed = 200.0f;
    private float maxSpeed = 6.0f;
    private float accelRate;
    private float turnRate;

    private bool normalAtt;
    private bool homingAtt;
    private bool waveAtt;

    private Rigidbody bulletRb;
    private Vector3 mvDir;

    GameObject target;
    //eAttackController attackController;
    //float limit = 20f;
    float moveLimit = 20f;


    void Start()
    {
        bulletRb= GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletRb.transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -moveLimit) // leftlim
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > moveLimit) //rightlim
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > moveLimit) //upperlim
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -moveLimit) //lowerlim
        {
            Destroy(gameObject);
        }
    }

    //private void EAttack(bool normalAttack, bool homingAttack, bool waveAttack)  //, Transform homingTarget, float initXAngle)
    //{
    //    Quaternion newAngle = transform.rotation;
    //    Vector3 newPosition;
    //    if (normalAttack) //go straight, accel
    //    {
    //        bulletRb.AddForce(bulletRb.transform.forward * speed);
    //        //return;
    //    }
    //    else if (homingAttack) //init homing to player
    //    {
    //        target = GameObject.FindGameObjectWithTag("Player");
    //        mvDir = (target.transform.position - transform.position).normalized;
    //        bulletRb.velocity = new Vector3(mvDir.x, mvDir.y, mvDir.z);
    //    }
    //    else if (waveAttack) //sinusoidal movement | keep var that changes 
    //    {
    //        return;
    //    }
    //
    //
    //
    //
    //
    //}

}
