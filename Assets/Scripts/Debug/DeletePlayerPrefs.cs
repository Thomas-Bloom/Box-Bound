﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.DeleteAll();

    }

}
