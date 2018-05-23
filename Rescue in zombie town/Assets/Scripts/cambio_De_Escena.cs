using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambio_De_Escena : MonoBehaviour {
    public void ir_Principal()
    {
        SceneManager.LoadScene("principal");
    }
    public void ir_score()
    {
        SceneManager.LoadScene("score");
    }
    public void ir_intro()
    {
        SceneManager.LoadScene("intro_Screen");
    }
    public void ir_gameover()
    {
        SceneManager.LoadScene("gameover");
    }
}
