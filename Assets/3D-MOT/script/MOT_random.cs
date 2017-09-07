using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOT_random : MonoBehaviour {


	public GameObject wall;
	public GameObject maincamera;

	// Use this for initialization
	void Start () {

		wall.transform.localScale = new Vector3 (60, 40, 10);
		//maincamera.transform.localPosition=new Vector2 (Screen.width / 2, Screen.height / 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
