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
                ghosts[position].GetComponent<Movement>().enabled = true;
                ghosts[position].GetComponent<AutomaticMovement>().enabled = false;
            } else {
                ghosts[position].GetComponent<Movement>().enabled = false;
                ghosts[position].GetComponent<AutomaticMovement>().enabled = true;    
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            Debug.Log(position);
            ghosts[position].GetComponent<Movement>().enabled = false;
            ghosts[position].GetComponent<AutomaticMovement>().enabled = true;
            position++;
            if (position == ghosts.Length){
                position = 0;
            }
            ghosts[position].GetComponent<Movement>().enabled = true;
            ghosts[position].GetComponent<AutomaticMovement>().enabled = false;
        }
    }
}
