using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public ObjectPool ManagerInstance;
    PooledObject prefab;
    public float spawnInterval = 1f;
    public float objectLifeTime = 10f;

   
    void Start()
    {
        StartCoroutine(CallObject());
    }

    IEnumerator CallObject()
    {
        while(true)
        {
            prefab = ManagerInstance.GetPooledObject();
            prefab.transform.position = this.transform.position;

            // Make sure to reset Rigidbody velocity to prevent unintended speed increase.(Only because the object has a rigidbody)
            Rigidbody rb = prefab.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;  // Reset velocity.
            }

            //Return object to pool
            StartCoroutine(ReturnObject(prefab));
            
            //wait for some seconds before pulling object again
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator ReturnObject(PooledObject prefab)
    {
        yield return new WaitForSeconds(objectLifeTime);

        //Checks if the game object is active. Object can be deactivated when hit with bullet
        if(prefab.gameObject.activeSelf)
        {
            prefab.ReturnToPoolAfterSeconds(0f);
        }
        
    }
}
