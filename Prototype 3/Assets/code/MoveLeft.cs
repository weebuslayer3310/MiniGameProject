using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour

{
    // Start is called before the first frame update
    private float speed = 20.0f;

    public float Leftboundary = -30.0f;

    private PlayerController PlayerControllerScript;

    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerScript.GameOver == false){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(transform.position.x < Leftboundary && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
    }
}
