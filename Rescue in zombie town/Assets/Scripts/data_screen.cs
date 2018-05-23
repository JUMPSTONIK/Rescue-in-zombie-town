using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class data_screen : MonoBehaviour {
    public int score;
    public Text Score;
    public Character valores;

    public Text life;
    public int vida;
    public int puntos;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score = Character.puntos;
        Score.text = "Score: " + score.ToString();

        vida = Character.life;
        life.text = "life " + vida.ToString();


    }
}
