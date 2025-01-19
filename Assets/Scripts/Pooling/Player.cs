using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ObjectPool prefabPool;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PooledObject prefab = prefabPool.GetPooledObject();
            prefab.transform.position = transform.position;
            
            prefab.ReturnToPoolAfterSeconds(20f);

        }
    }
}
