using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour {

    BoxCollider2D col;

    Vector2 size;
    Vector3 centerPoint;
    Vector3 worldPos;

    public GameObject floor;
    public bool rightLedge;


    float top;
    float btm;
    float left;
    float right;

    // Use this for initialization
    void Start () {

        //Sprawdza po ktorej stronie dac krawedz do lapania i oblicza pozycje krawedzi wzgledem podlogi
        if (rightLedge == true) {
            transform.localPosition= new Vector3((0.141f / 2) - 0.003f, 0, 0);
        }
        else
            transform.localPosition = new Vector3(-(0.141f / 2) + 0.003f, 0, 0);

        col = GetComponent<BoxCollider2D>();
        size = col.size;
        centerPoint = new Vector3(col.offset.x, col.offset.y, 0f);
        Vector3 worldPos = transform.TransformPoint(col.offset);

        top = worldPos.y + (size.y / 2f);
        btm = worldPos.y - (size.y / 2f);
        left = worldPos.x - (size.x / 2f);
        right = worldPos.x + (size.x / 2f);

        Vector3 topLeft = new Vector3(left, top, worldPos.z);
        Vector3 topRight = new Vector3(right, top, worldPos.z);
        Vector3 btmLeft = new Vector3(left, btm, worldPos.z);
        Vector3 btmRight = new Vector3(right, btm, worldPos.z);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetLeft()
    { 
            return left;
    }

    public float GetTop()
    {
        return top;
    }
}
