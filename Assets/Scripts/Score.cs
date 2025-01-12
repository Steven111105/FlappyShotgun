using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Action OnScore;
    public static int score = 0;
    [SerializeField] bool isCombo = false;
    [SerializeField] float comboTimer = 4f;
    [SerializeField] int multiplier = 1;
    [SerializeField] Text scoreText;

    AudioSource audioSource;
    [SerializeField] AudioClip[] comboSFX;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        audioSource = GetComponent<AudioSource>();
        OnScore += IncreaseScore;
    }

    public void IncreaseScore(){
        StopAllCoroutines();
        if(isCombo){
            if(multiplier < 8){
                multiplier<<=1;
            }
        }
        else{
            isCombo = true;
            multiplier = 1;
        }
        PlayComboSound();
        StartCoroutine(ComboTimer());
        score += 1 * multiplier;
        scoreText.text = "Score: " + score;
    }

    IEnumerator ComboTimer(){
        yield return new WaitForSeconds(comboTimer);
        isCombo = false;
        multiplier = 1;
    }

    void PlayComboSound(){
        switch(multiplier){
            case 1:
                audioSource.PlayOneShot(comboSFX[0]);
                break;
            case 2:
                audioSource.PlayOneShot(comboSFX[1]);
                break;
            case 4:
                audioSource.PlayOneShot(comboSFX[2]);
                break;
            case 8:
                audioSource.PlayOneShot(comboSFX[3]);
                break;
        }
    }

    private void OnDestroy()
    {
        OnScore -= IncreaseScore;
    }
}
