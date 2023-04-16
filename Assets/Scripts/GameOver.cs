using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {  
        if (other.gameObject.CompareTag("Player")){
            gameManager.isOver = true;
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
    }
}
