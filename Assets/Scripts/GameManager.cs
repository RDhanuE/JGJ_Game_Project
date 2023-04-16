using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isOver;
    private GameObject gameOverScreen;
    private void Start() {
        isOver = false;
        gameOverScreen =  this.transform.GetChild(0).gameObject;
        gameOverScreen.SetActive(false);
    }

}
