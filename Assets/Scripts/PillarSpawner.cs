using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pillarPrefab;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            Vector3 spawnPosition = new Vector3(player.position.x +  10 + (10*i) , Random.Range(-3f, 3f), 0);
            if(i == 0){
                spawnPosition = new Vector3(spawnPosition.x, 0, 0);
            }
            // Debug.Log("Spawning at: " + spawnPosition);
            Instantiate(pillarPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
