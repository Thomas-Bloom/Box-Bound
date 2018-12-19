using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float moveSpeed;
    public GameManager gm;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(gm.playerIsActive)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        
	}
}
