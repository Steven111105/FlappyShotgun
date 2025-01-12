using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



public class Player : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    [SerializeField] float shootForce = 10f;
    bool hasStarted = false;
    private Transform gun;
    AudioSource audioSource;
    [SerializeField] AudioClip shootSFX;
    public static Action OnGameOver;
    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gun = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameOverScript.isGameOver){
            if (Input.GetMouseButtonDown(0) && !hasStarted)
            {
                hasStarted = true;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = Vector2.zero;
                rb.AddForce(direction.normalized * shootForce, ForceMode2D.Impulse);
                PlayShootSound();
                return;
            }
            //add impulse away from the cursor
            direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            gun.transform.rotation = Quaternion.Euler(0,0,angle + 180f);
            if (Input.GetMouseButtonDown(0) && hasStarted)
            {
                rb.velocity *= 0.5f;
                rb.AddForce(direction.normalized * shootForce, ForceMode2D.Impulse);
                PlayShootSound();
            }
        }
    }

    void PlayShootSound()
    {
        //random pitch shift
        float pitch = UnityEngine.Random.Range(0.9f, 1.2f);
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(shootSFX);
    }
}
