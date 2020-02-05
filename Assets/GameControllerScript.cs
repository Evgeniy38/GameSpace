using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public GameObject menuScreen;
    public Button startButton;

    public Text scoreText; //public UnityEngine.UI.Text scoreText;
    private int score = 0;

    private bool isStarted = false; //Game pause

    private bool gameOver = false;
    private float delay;

    public bool getGameOver()
    {
        return gameOver = true;
    }
    public bool getIsSterted()
    {
        return isStarted;
    }

    private static GameControllerScript instance;

    public static GameControllerScript getInstance()
    {
        return instance;
    }
    public void increaseScore(int increment)
    {
        score += increment;
        scoreText.text = "Score: " + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //if click on button start
        startButton.onClick.AddListener(delegate
        {
            gameOver = false;
            menuScreen.SetActive(false); // Remuve Menu
            isStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {
            menuScreen.SetActive(true); //play menu
            isStarted = false; // stop asteroids

        }

    }
}
