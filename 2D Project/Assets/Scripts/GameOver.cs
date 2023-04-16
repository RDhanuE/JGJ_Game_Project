using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioSource audioSource;
    private float volume = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {  
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Game Over");
            Time.timeScale = 0f;
            audioSource.PlayOneShot(audioSource.clip, volume);
        }
    }
}
