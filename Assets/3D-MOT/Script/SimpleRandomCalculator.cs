using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimpleRandomCalculator : MonoBehaviour {

	[SerializeField]
	private Text text1;
	[SerializeField]
	private Text text2;
	[SerializeField]
	private Text CalcText;

	private float TimerCount = 0;
	private string[] CalcMeth = { "+", "ー" };
	private int a = 10;


	// Use this for initialization
	void Start () {
		text1.text = Random.Range (10, 51).ToString ();
		text2.text = Random.Range (10, 51).ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		TimerCount += Time.deltaTime;
		//Debug.Log (TimerCount);

		if (TimerCount >= a) {
			text1.text = Random.Range (10, 51).ToString ();
			text2.text = Random.Range (10, 51).ToString ();

			if (a % 4 == 0) {
				CalcText.text = CalcMeth [0];
			}else{
				CalcText.text = CalcMeth [1];
			}

			a += 10;
		}

	}


}
