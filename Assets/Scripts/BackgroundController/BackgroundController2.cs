using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController2 : MonoBehaviour
{
    Vector3 startPos;
    float repeatWidth;
    [SerializeField] float x,y,z;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.y/5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = this.transform.position - new Vector3(x,y,z) * Time.deltaTime;
        if(transform.position.y < startPos.y - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
