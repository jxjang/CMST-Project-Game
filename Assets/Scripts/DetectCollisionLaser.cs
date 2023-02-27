using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollisionLaser : MonoBehaviour
{
    public GameObject fxExplosion;

    // Start is called before the first frame update
    void Start()
    {
        if (fxExplosion == null)
        {
            Debug.LogError("Explosion prefab not attached to script!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathAnim(GameObject other)
    {
        Vector3 initLoc = other.transform.position;
        Destroy(other);
        Instantiate(fxExplosion, initLoc, Quaternion.identity);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        if (other.gameObject.name != "PlayerAttack")
        {
            StartCoroutine(DeathAnim(other.gameObject));

            Destroy(gameObject);
        }
    }
}
