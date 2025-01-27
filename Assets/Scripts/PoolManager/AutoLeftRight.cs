using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLeftRight : MonoBehaviour
{
    Vector3 dir = Vector3.left;
    public float speed = 2f;
    public float TimeInterval = 4f;

    void Start()
    {
        
        SetRandomDir();

        StartCoroutine(TimeToChange());

    }


    void Update()
    {
        //Continuous movement in left/right direction
        this.transform.Translate(dir * Time.deltaTime * speed);

        //Clamping between boundaries
        float clampedX = Mathf.Clamp(this.transform.position.x,-9f,9f);
        this.transform.position = new Vector3(clampedX,this.transform.position.y,this.transform.position.z);

        if(clampedX==9f){
            dir = Vector3.left;
        }
        else if(clampedX==-9f)
        {
            dir = Vector3.right;
        }
    }

    IEnumerator TimeToChange()
    {
        while(true)
        {
            yield return new WaitForSeconds(TimeInterval);

            SetRandomDir();
        }
        
    }

    void SetRandomDir()
    {
        //Random.value return value between 0 and 1
        if(Random.value>0.5f)
        {
            dir = Vector3.left;
        }
        else{
            dir = Vector3.right;
        }
    }
}
