using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameOverScript.OnGameOver();
    }
}
