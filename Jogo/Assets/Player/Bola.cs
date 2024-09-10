using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{

    public Rigidbody2D PlayerBody;
    public GameObject PortaVerde;
    public GameObject PortaAzul;
    public GameObject PortaVermelha;
    public GameObject GameEngine;
    public Text MensagemChave;
    private int timecounter;
    private bool StartGame;
    private bool GameOver;
    private bool canMove;
    private bool Victory;
    private float x, z;
    private double Segundos;
    private bool i;

    void Start()
    {
        StartGame = false;
        GameOver = false;
        Victory = false;
        canMove = true;
        timecounter = 0;
        PlayerBody = GetComponent<Rigidbody2D>();
        Segundos = 0;
    }

   
    void Update()
    {
        x = this.transform.position.x;
        z = this.transform.position.z;
        if (!Victory && x > 14 && z > -5)
        {
            GameEngine.SendMessage("Victory");
            Victory = true;
        }

        if (!StartGame)
        {
            GameEngine.SendMessage("GameStarPause");
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey("enter"))
            {
                GameEngine.SendMessage("GameStart");
                StartGame = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey("enter"))
        {
            if (GameOver || Victory)
            {
                GameEngine.SendMessage("RestartGame");
            }
        }

        timecounter++;

        if (timecounter >= 400 && canMove == false)
            {
                Debug.Log("Pode mover");
                canMove = true;
            }

       if (canMove)
        {
            
            if (Input.GetKeyDown("w"))
            {
                PlayerBody.AddForce(new Vector2(0, 150));
                canMove = false;
            }
            else if (Input.GetKeyDown("s"))
            {
                PlayerBody.AddForce(new Vector2(0, -150));
                canMove = false;
            }
            else if (Input.GetKeyDown("a"))
            {
                PlayerBody.AddForce(new Vector2(-150, 0));
                canMove = false;
            }
            else if (Input.GetKeyDown("d"))
            {
                PlayerBody.AddForce(new Vector2(150, 0));
                canMove = false;
            }
        }            


        if(GameOver == true)
        {
            timecounter = 0;
            canMove = false;
            PlayerBody.AddForce(Vector2.zero);
            GameEngine.SendMessage("GameOver");
        }

        if (Segundos > 5)
        {
            Segundos = 0;
            MensagemChave.text = "";
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Foe"))
        { 
            GameOver = true;
            GameEngine.SendMessage("GameOver");
        }
        
        if (collision.gameObject.CompareTag("wall") || 
            collision.gameObject.CompareTag("PortaAzul") || 
            collision.gameObject.CompareTag("PortaVermelha") || 
            collision.gameObject.CompareTag("PortaVerde"))
        {
            Debug.Log("Colidiu com um bloco");
            PlayerBody.AddForce(Vector2.zero);
            canMove = true;
            timecounter = 0;
        }

        if (collision.gameObject.CompareTag("ChaveVerde"))
        {
            Debug.Log("Colidiu com a chave");
            collision.gameObject.SetActive(false);
            PortaVerde.SetActive(false);
            MensagemChave.text = "Bruno...";

            Segundos += Time.deltaTime;

        }
        if (collision.gameObject.CompareTag("ChaveVermelha"))
        {
            Debug.Log("Colidiu com a chave");
            collision.gameObject.SetActive(false);
            PortaVermelha.SetActive(false);
            MensagemChave.text = "Laura...";

            Segundos += Time.deltaTime;

        }
        if (collision.gameObject.CompareTag("ChaveAzul"))
        {
            Debug.Log("Colidiu com a chave");
            collision.gameObject.SetActive(false);
            PortaAzul.SetActive(false);
            MensagemChave.text = "Ana...";

            Segundos += Time.deltaTime;
        }
        
    }


}