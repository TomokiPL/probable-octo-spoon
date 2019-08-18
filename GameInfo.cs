using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour {

   // public CharacterMovement Character;

    //UI
    private int score;
    private int lives;
    public Text scoreText;
    public Text livesText;
    public Text winner;

    //Player Info
    public GameObject player;
    public float startY;
    public float startX;
    // Use this for initialization
    void Start () {
        GetStartPosition();
        score = 0;
        lives = 3;
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Gracz zdobywa punkt
    public void GetScore()
    {
        score+=1;
        scoreText.text = "Score: " + score.ToString();
    }

    //Gracz traci zycie i wraca do pozycji startowej poziomu
    public void LostLife()
    {
        lives-=1;
        livesText.text = "Lives: " + lives.ToString();
        if (lives > 0)
            SetStartPosition();
        else
            player.SetActive(false);
    }

    //Aktywuje napis winner
    public void Win()
    {
        winner.gameObject.SetActive(true);
    }


    //Ustawia pozycje startowa gracza
    public void GetStartPosition()
    {
        startY = player.transform.position.y;
        startX = player.transform.position.x;
    }

    //Ustawia gracza w pozycji startowej
    public void SetStartPosition()
    {
        player.transform.position = new Vector3(startX, startY);
    }
}
