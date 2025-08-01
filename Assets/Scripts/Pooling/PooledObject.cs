using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    ObjectPool pool;
    public ObjectPool Pool { get => pool; set => pool = value;}

    public void Release()
    {
        pool.ReturnToPool(this);
    }

    public void ReturnToPoolAfterSeconds(float seconds)
    {
        StartCoroutine(ReturnAfterDelay(seconds));
    }

    IEnumerator ReturnAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Release();
    }
}
