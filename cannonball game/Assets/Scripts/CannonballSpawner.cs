using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballSpawner : MonoBehaviour
{
    //Edwin Aguirre
    
    [SerializeField]
    private GameObject cannonball;

    [SerializeField]
    private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawns the cannonballs
    public void OnClickSpawnCannonball()
    {
        Instantiate(cannonball, spawnPoint.position, Quaternion.identity);
    }
}
