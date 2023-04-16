using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alternate : MonoBehaviour
{
    public GameObject[] ghosts = new GameObject[2];
    private int position = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0 ; i < ghosts.Length ; i++){
            if (i == 0){
                ghosts[i].GetComponent<Movement>().enabled = true;
                ghosts[i].GetComponent<AutomaticMovement>().enabled = false;
                ghosts[i].transform.GetChild(0).gameObject.SetActive(true);
            } else {
                ghosts[i].GetComponent<Movement>().enabled = false;
                ghosts[i].GetComponent<AutomaticMovement>().enabled = true;    
                ghosts[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            ghosts[position].GetComponent<Movement>().enabled = false;
            ghosts[position].GetComponent<AutomaticMovement>().enabled = true;
            ghosts[position].transform.GetChild(0).gameObject.SetActive(false);
            position++;
            if (position == ghosts.Length){
                position = 0;
            }
            ghosts[position].GetComponent<Movement>().enabled = true;
            ghosts[position].GetComponent<AutomaticMovement>().enabled = false;
            ghosts[position].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
