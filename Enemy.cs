using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


       
    public int turn; //Turn 1=right//////-1=left
    public float defaultSpeed;  //Default movment speed
    public float rageSpeed; //Speed when see Player
    private float currentSpeed; //Current movment speed
    

    private Rigidbody2D body;
    private SpriteRenderer sprite;

    public LayerMask wallLayer;
    public LayerMask playerLayer;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        currentSpeed = defaultSpeed;

    }
	
	// Update is called once per frame
	void Update () {

        NearWall();  
        SeePlayerTest1();
        OnGround();
        body.velocity = new Vector2(turn*currentSpeed, body.velocity.y);
    }


    //Check wall hit, if yes turn around
    private void NearWall()
    {
        Vector2 position = transform.position;
        Vector2 direction = new Vector2(0.3f*turn, 0);
        float distance = 0.3f;
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, wallLayer);
        if (hit.collider != null)
        {
            turn *= -1;
            return;
        }
        return;
    }

    //Check ground hit, if no turn around
    private void OnGround()
    {
        {
            Vector2 position = transform.position;
            Vector2 direction = new Vector2(turn, -1);
            float distance = 1f;
            Debug.DrawRay(position, direction, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, wallLayer);
            if (hit.collider == null)
            {
                turn *= -1;
                return;
            }
            return;
        }
    }

    //Check if see player if see speed up, if not back to patrol speed
    private void SeePlayer()
    {
        Vector2 position = transform.position;
        Vector2 direction = new Vector2(turn*5, 0);
        float distance = 5.0f;
        Debug.DrawRay(position, direction, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, playerLayer);
        if (hit.collider != null)
        {
            if (hit.collider.name == "Player") { 
                Debug.Log("Widze Cie!!");
                currentSpeed = rageSpeed;
            }
            else
            {
                Debug.Log("Gdzie jestes?!!?!");
                currentSpeed = defaultSpeed;
            }
        }
        return;
    }

    private void SeePlayerTest1()
    {
        Vector2 position = transform.position;
        Vector2 direction = new Vector2(turn * 5, 0);
        Vector2 size = new Vector2(3, 3);
        float angle = 0f;
        float distance = 5.0f;
        RaycastHit2D hit = BoxCastScript.BoxCast(position, size, angle, direction, distance, playerLayer);    // Need BoxCastScript to work u can find it on my github
        if (hit.collider != null)
        {
            if (hit.collider.name == "Player")
            {
                Debug.Log("Widze Cie!!");
                currentSpeed = rageSpeed;
            }
            else
            {
                Debug.Log("Gdzie jestes?!!?!");
                currentSpeed = defaultSpeed;
            }
        }
    }

    

        private void SeePlayerTest2()
    {
        Vector2 position = transform.position;
        Vector2 direction = new Vector2(turn * 5, 0);
        float distance = 5.0f;
    }


    



}
