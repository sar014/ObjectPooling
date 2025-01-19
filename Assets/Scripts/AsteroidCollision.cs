using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    PooledObject pooledObject;
    void Start()
    {
        pooledObject = this.GetComponent<PooledObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bullets"))
        {
            this.pooledObject.ReturnToPoolAfterSeconds(0f);
        }
        
    }
}
