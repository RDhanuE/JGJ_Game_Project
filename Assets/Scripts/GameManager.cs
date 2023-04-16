using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject gameOverScreen;
    [SerializeField]private Button retryButton;
    private void Start() {
        IsOver(false);
        retryButton = gameOverScreen.GetComponentInChildren<Button>();
        retryButton.onClick.AddListener(delegate { ReloadScene(); });
    }
    public void IsOver(bool isOver) {
        if (isOver) {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
        else {
            Time.timeScale = 1;
            gameOverScreen.SetActive(false);
        }
    }
    private void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
