using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour {


	[SerializeField]
	private Text CountText;
	private float CountDouwn = 5;
	private bool flag = false;

	// Use this for initialization
	void Start () {
		CountText.text = "5";
		//CountText.text = CountDouwn.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		if (flag == true) {
			Debug.Log (CountDouwn);
			CountDouwn -= Time.deltaTime;

			if (CountDouwn <= 0) {
				CountText.text="0";
				SceneManager.LoadScene ("3D_MOT");
			}


				
		}
		CountText.text =((int)CountDouwn).ToString ();

	}
	public void LoadScene(){
		//SceneManager.LoadScene ("3D_MOT");
		flag = true;
	}
}
