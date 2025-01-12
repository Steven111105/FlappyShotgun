using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float maxX = 0f;
    Vector3 position;

    private void Start()
    {
        position = new Vector3(player.position.x, 0, -10f);
        maxX = 0;
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Max X: " + maxX);
        maxX = Mathf.Max(player.position.x-3f, maxX);
        position.x = Mathf.Max(player.position.x, maxX);
        transform.position = position;
    }
}
