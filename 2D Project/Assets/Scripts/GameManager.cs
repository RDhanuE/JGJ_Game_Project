using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject gameOverScreen;
    [SerializeField]private Button retryButton;
    [SerializeField]private Button exitButton;
    [SerializeField]private List<GameObject> ghosts = new List<GameObject>();
    [SerializeField]private GameObject cat;
    private void Start() {
        IsOver(false, null);
        retryButton = gameOverScreen.transform.GetChild(1).GetComponent<Button>();
        retryButton.onClick.AddListener(delegate { ReloadScene(); });
        exitButton = gameOverScreen.transform.GetChild(2).GetComponent<Button>();
        exitButton.onClick.AddListener(delegate { ExitGame(); } );
        List<Vector2> ghostA_spawnPos = new List<Vector2>(3);
        List<Vector2> ghostB_spawnPos = new List<Vector2>(3);
        List<Vector2> cat_spawnPos = new List<Vector2>(3);
        for (int i = 0; i < 3; i++) {
            ghostA_spawnPos.Add(GameObject.Find($"Spawn{i+1}_a").transform.position);
            ghostB_spawnPos.Add(GameObject.Find($"Spawn{i+1}_b").transform.position);
            cat_spawnPos.Add(GameObject.Find($"Spawn{i+1}_c").transform.position);
        }
        
        int x = Random.Range(0, 3);
        ghosts[0].GetComponent<AutomaticMovement>().movePoint.position = ghostA_spawnPos[x];
        ghosts[0].transform.position = ghostA_spawnPos[x];
        Debug.Log(x);
        x = Random.Range(0, 3);
        Debug.Log(x);
        ghosts[1].GetComponent<AutomaticMovement>().movePoint.position = ghostB_spawnPos[x];
        ghosts[1].transform.position = ghostB_spawnPos[x];
        x = Random.Range(0, 3);
        Debug.Log(x);
        cat.GetComponent<CatMovement>().movePoint.position = cat_spawnPos[x];
        cat.transform.position = cat_spawnPos[x];
    }
    public void IsOver(bool isOver, string winner) {
        if (isOver) {
            Time.timeScale = 0;
            gameOverScreen.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = (winner + " win").ToUpper();
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
    public void ExitGame()
    {
        Application.Quit();
        Time.timeScale = 1;
    }
}

