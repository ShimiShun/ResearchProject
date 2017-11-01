using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundPlay : MonoBehaviour {



	public AudioSource _soundPlay;

	// Use this for initialization
	void Start () {
		_soundPlay = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
