using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    bool hasScored = false;

    private void Start()
    {
        hasScored = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Camera.main.transform.position.x - 20f)
        {
            Instantiate(gameObject, new Vector3(transform.position.x + 100f, Random.Range(-3f, 3f), 0), Quaternion.identity);
            Destroy(gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(!hasScored){
                hasScored = true;
                Score.OnScore();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision.gameObject.GetComponent<Player>().GameOver();
            GameOverScript.OnGameOver();
        }
    }
}
