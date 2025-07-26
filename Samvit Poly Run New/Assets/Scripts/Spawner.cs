using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("ChallengeObj Game Object")]
    public GameObject challengeObject;
    [Header("Default delay spawn time")]
    public float spawnDelay = 1f;
    [Header("Default spawn time")]
    public float spawnTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateObjects", spawnDelay, spawnTime);
        }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(5, 0f, 0);
        if (Input.GetKey(KeyCode.Space))
        {
            spawnTime = 0.1f;
        }
            
    }

        void InstantiateObjects()
    {
    Instantiate(challengeObject, transform.position, transform.rotation);
    }
}

    
