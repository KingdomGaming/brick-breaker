﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {

	void Start()
	{
		if(GameObject.FindObjectOfType<MusicPlayer>())
		{
			Destroy(GameObject.FindObjectOfType<MusicPlayer>().gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
