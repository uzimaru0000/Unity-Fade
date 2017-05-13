using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	Fade fader;

	// Use this for initialization
	void Start () {
		fader = Camera.main.GetComponent<Fade>();
		fader.FadeIn(5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
