using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public ObjectPool BulletInstance;
    PooledObject prefab;
    bool isShooting = false;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float objectLifeTime = 10f;
    [SerializeField] float ForceMultipler = 5f;
    [SerializeField] GameObject rocket;
    void Start()
    {

    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CallObject());
        }
        
    }

    IEnumerator CallObject()
    {
        if(isShooting) yield break;

        else
        {

            isShooting = true;

            prefab = BulletInstance.GetPooledObject();
            prefab.transform.SetPositionAndRotation(rocket.transform.position + rocket.transform.up, rocket.transform.rotation);


            // Make sure to reset Rigidbody velocity to prevent unintended speed increase.(Only because the object has a rigidbody)
            Rigidbody rb = prefab.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;

                //Apply Force in the Rocket's Forward Direction
                rb.AddForce(rocket.transform.up * ForceMultipler, ForceMode.Impulse);
            }

            //Return to pool
            StartCoroutine(ReturnObject(prefab));

            yield return new WaitForSeconds(spawnInterval);
            isShooting = false;
        }
    }

    IEnumerator ReturnObject(PooledObject prefab)
    {
        yield return new WaitForSeconds(objectLifeTime);
        prefab.ReturnToPoolAfterSeconds(0f);
    }
}
