using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour {

    public GameInfo GameInfo;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Moneta") { 
            GameInfo.GetScore();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GameInfo.LostLife();
        }
        if (collision.gameObject.name == "Finish")
            GameInfo.Win();
    }

   
}
