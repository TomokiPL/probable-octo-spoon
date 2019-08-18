using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    //Kierunek w jakim wróg się porusza oraz szybkość
    public float zwrot;

    private Rigidbody2D body;
    private SpriteRenderer sprite;

    //Obiekty wykrywajace przeszkody
    public GameObject wallDetector;
    public GameObject groundDetector;
    public GameObject jumpDetector;

    //Skrypty do detektorów
   // Detectors groundDetectorScript;



    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
       // Detectors groundDetectorScript = groundDetector.GetComponent<Detectors>();
    }
	
	// Update is called once per frame
	void Update () {
        //TEST RAYCASTING
        Vector3 pos = transform.position;
        Vector3 newpos = transform.position + new Vector3(0, 1);
        print(newpos);
        Debug.DrawLine(pos, newpos, Color.red, 2, true);
        //zwrot = zwrot * Time.deltaTime * speed;
        if (groundDetector.GetComponent<Detectors>().GetColide() != true)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x*-1, this.transform.localScale.y);
            //Odwraca kierunek ruchu
            zwrot *= -1;
        }
        else if(wallDetector.GetComponent<Detectors>().GetColide() == true)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y);
            //Odwraca kierunek ruchu
            zwrot *= -1;
        }

            
            
        body.velocity = new Vector2(zwrot, body.velocity.y);
    }


    



}
