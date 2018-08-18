using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject GameOverText;
    public GameObject UI;


	void Start () {

        GameOverText.SetActive(true);
        UI.SetActive(false);
        Time.timeScale = 0.0f;  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
