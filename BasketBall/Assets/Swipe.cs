using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    Vector2 startpos, endpos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [Range(0.05f,1f)]
    public float throwForce = 0.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Began)
        {
            Debug.Log("thouchphase begin");
            touchTimeStart = Time.time;
            startpos = Input.GetTouch(0).position;
        }

        if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Ended)
        {
            Debug.Log("Touchphase ended");
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endpos = Input.GetTouch(0).position;
            direction = startpos - endpos;
            GetComponent<Rigidbody2D>().AddForce(-direction / timeInterval * throwForce);
        }
	}
}
