using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioSource audioSource;
    private float volume = 0.8f;
    private GameManager gameManager;
    private int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Fishies") == null && counter != 0){
            Debug.Log("Game Over");
            gameManager.IsOver(true);
            audioSource.PlayOneShot(audioSource.clip, volume);
            counter--;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {  
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Game Over");
            gameManager.IsOver(true);
            audioSource.PlayOneShot(audioSource.clip, volume);
        }
    }
}
