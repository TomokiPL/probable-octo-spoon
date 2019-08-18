using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectors : MonoBehaviour {

    public bool colide;
    public string objectToDetect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == objectToDetect)
            colide = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == objectToDetect)
            colide = false;
    }

    public bool GetColide()
    {
        return colide;
    }
}
