using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCoins : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 15);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
