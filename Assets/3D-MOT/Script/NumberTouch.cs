using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class NumberTouch : MonoBehaviour {

	[SerializeField]
	private List<GameObject> NumsBalls;

	private int[] array=new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
	private int[] NumArray;

	[SerializeField]
	private string TouchNum;
	[SerializeField]
	private GameObject TimerText;
	private int TouchCount = 1;
	private float TimerCount = 0;

	bool flag = true;
	bool StartFalg = false;
	[SerializeField]
	private GameObject StartButton;
	[SerializeField]
	private GameObject ResetButton;

	// Use this for initialization
	void Start () {
		
		ResetButton.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (StartFalg == true) {

			if (flag == true) {
				TimerCount += Time.deltaTime;
				TimerText.GetComponent<TextMesh> ().text = TimerCount.ToString ("F3");
			}


			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit)) {
					var selectedObj = hit.collider.gameObject; 
					var NumText = int.Parse (selectedObj.transform.Find ("Number").GetComponent<TextMesh> ().text);

					if (NumText == TouchCount) {
						selectedObj.GetComponent<MeshRenderer> ().material.color = Color.red;
						TouchCount++;
						Debug.Log (TouchCount);


					}
				}
			}

			if (TouchCount == 21) {//21
				//Debug.Log ("Completed");
				flag = false;
				StartFalg = false;
				ResetButton.SetActive (true);
			}
		}
	}


	public void StartTouchNumber(){
		ShuffleNumber ();

		StartFalg = true;
		StartButton.SetActive(false);
		flag = true;
	}


	public void ResetGame(){
		StartButton.SetActive (true);
		ResetButton.SetActive (false);
		TimerCount = 0;
		TouchCount = 1;
		TimerText.GetComponent<TextMesh> ().text="0.00";
		for (int i = 0; i < NumsBalls.Count; i++) {
			NumsBalls [i].GetComponent<MeshRenderer> ().material.color = Color.black;
		}
	}


	private void ShuffleNumber(){
		NumArray = array.OrderBy(i => Guid.NewGuid()).ToArray();

		for (int i = 0; i < NumArray.Length; i++) {
			NumsBalls [i].transform.Find ("Number").GetComponent<TextMesh> ().text = NumArray [i].ToString ();
		}
	}
}
