using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ObstaclePrefab;
    public float StartTime = 3f;
    public float TimeBetween = 0.7f;
    private Vector3 SpawnPosition = new Vector3(21, 0, 0);
    private PlayerController PlayerControllerScript;
    void Start()
    {
        InvokeRepeating("SpawnObstacles", StartTime, TimeBetween);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles(){
        if(PlayerControllerScript.GameOver == false){
            Instantiate(ObstaclePrefab, SpawnPosition, ObstaclePrefab.transform.rotation);
        }
        
    }
}
