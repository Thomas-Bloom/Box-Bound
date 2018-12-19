using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandShrinkButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExpandButton()
    {
        GetComponent<Animator>().Play("Button_Expand");
    }

    public void ShrinkButton()
    {
        GetComponent<Animator>().Play("Button_Shrink");
    }
}
