using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 StartPosition;
    private float BackgroundWidth;
    void Start()
    {
        StartPosition = transform.position;
        BackgroundWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < StartPosition.x - BackgroundWidth){
            transform.position = StartPosition;
        }        
    }
}
