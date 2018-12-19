using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownwards : MonoBehaviour {

    public float moveSpeed;

	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);	
	}
}
