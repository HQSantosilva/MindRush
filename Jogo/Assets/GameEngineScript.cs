using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEngineScript : MonoBehaviour
{
    private double Segundos;
    private int Minutos;
    public Text TempoText;
    public Text MessageText;
    public GameObject video;
    public int TimeToStop;
    private double TempoVitoria;
    // Start is called before the first frame update
    void Start()
    {
        Segundos = 0;
        Minutos = 0;
        MessageText.text = "";
        Time.timeScale = 1;
        video.SetActive(false);
        TempoVitoria = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        if (TempoVitoria > 25)
        {
            RestartGame();
        }
    }

    void GameStarPause()
    {
        Time.timeScale = 0;
        //Segundos = 0;
        //Minutos = 0;
        MessageText.text = "Aperte ENTER para começar";
    
    }

    void GameStart()
    {
        MessageText.text = "";
        Time.timeScale = 1;
    }

    void GameOver()
    {
        Time.timeScale = 0;
        MessageText.text = "Game Over! Aperte ENTER para reiniciar";

    }

    void Victory()
    {
        //Time.timeScale = 0;

        video.SetActive(true);
        Destroy(video, TimeToStop);
       if(TimeToStop == 25)
        {
            RestartGame();
        }
    }

    void Timer()
    {
        
        Segundos += Time.deltaTime;
        Segundos = Math.Round(Segundos, 2);
        int SegundosInt = Convert.ToInt32(Segundos);

        if (Segundos >= 60)
        {
            Minutos++;
            Segundos = 0;
        }

        TempoText.text = "Tempo: " + Minutos.ToString() + ":" + SegundosInt.ToString();
    }
    void RestartGame()
    {
        SceneManager.LoadScene("Stage");
      
    }
}
