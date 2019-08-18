using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    //Szybkość gracza
    public int speed;
    //Czy jest w powietrzu
    public bool air;
    //Sila skoku
    public int jumpPower;
    //Czy chwyta sie krawedzi
    public bool grabbed;
    //Pobieranie wartosci ruchu
    private float x;
    private float y;

    private Rigidbody2D body;
    private SpriteRenderer sprite;


    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        //Dostosowanie szybkosci ruchu
        x = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        //Obrót sprite
        if (x > 0)
            sprite.flipX = false;
        else
            sprite.flipX = true;
        //Sprawdza czy gracz znajduje sie w powietrzu jesli nie to podskakuje
        if (Input.GetButtonDown("Jump")==true && air==false)
        {
            Jump();
        }
        //Czy chararakter chwycil krawedz
        if(grabbed==false)
            //Przesuwanie sprite
            body.velocity = new Vector2(x * 100, body.velocity.y);
        else
        {
            
            if (Input.GetButtonDown("Jump") == true)
            {
                //Drop();
                StartCoroutine(Climb(0.1f));
                
                // Jump();
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                Drop();
            }
        }
        
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Sprawdza czy postac dotyka na ziemi
        if (collision.gameObject.tag == "Ground")
            air = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            air = false;
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Sprawdza czy postac przestala dotykac ziemi
        if (collision.gameObject.tag == "Ground")
            air = true;
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Edge") {
            grabbed = true;
            //body.isKinematic = true;
            body.gravityScale = 0;
            transform.position=new Vector3(transform.position.x, collision.GetComponent<Ledge>().GetTop());
            body.velocity = new Vector3(0, 0, 0);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Edge") { 
            grabbed = false;
           
        }
    }




    private void Drop()
    {
        //body.simulated = true;
        body.gravityScale = 3;
        grabbed = false;
        body.AddForce(new Vector2(0, -1), ForceMode2D.Impulse);

    }

    private void Jump()
    {
        body.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        air = true;
    }

    private IEnumerator Climb(float wait)
    {
        //body.isKinematic = false;
        body.gravityScale = 3;
        yield return new WaitForSeconds(wait);
        body.AddForce(new Vector2(0, jumpPower+5), ForceMode2D.Impulse);
        /*
        if (sprite.flipX == true) {
            Debug.Log(sprite.flipX);
            body.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            
            body.velocity = new Vector3(0, 100);
            body.velocity = new Vector3(50, 0);
            body.AddForce(new Vector2(0, 115), ForceMode2D.Force);
           
        }
        else { 
            Debug.Log(sprite.flipX);
            body.AddForce(new Vector2(-5, 2), ForceMode2D.Force);
        }
        yield return new WaitForSeconds(wait);
         */
    }
}
