﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class StartScript : MonoBehaviour {


	[SerializeField]
	private Text CountText;
	private float CountDouwn = 5;
	private bool flag = false;

	[SerializeField]
	private GameObject StartButton;
	[SerializeField]
	private GameObject Level1Button;
	[SerializeField]
	private GameObject Level2Button;
	[SerializeField]
	private GameObject Level3Button;
	private int LoadSceneNum;
	private string LoadSceneName;

	[SerializeField]
	private Text num;
	[SerializeField]
	private Text gend;

	public static string Numbers = "";
	public static string Gender = "";
	public static int a = 0;

	// Use this for initialization
	void Start () {
		CountText.text = "連続タッチ！！";
		//CountText.text = CountDouwn.ToString ();
		StartButton.SetActive(false);

		num.text=TouchEventScript.StudentNumber;
		//gend.text = TouchEventScript.Gender;

		ListCollisionCollor.CountPurple = 0;
		ListCollisionCollor.CountPink = 0;
		ListCollisionCollor.CountSkyblue = 0;
		CreatedObject.NoTouchCount = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if (a == 0) {
			Numbers = num.text;
			Gender = gend.text;
		} 
			



		switch (LoadSceneNum) {
		case 1:
			a++;
			LoadSceneName = "3DMOT_Lvl1";
			break;

		case 2:
			a++;
			LoadSceneName = "3DMOT_Lvl2";
			break;

		case 3:
			a++;
			LoadSceneName = "3DMOT_Lvl3";
			break;
		}


		if (flag == true) {
			CountText.text =((int)CountDouwn).ToString ();
			//Debug.Log (CountDouwn);
			CountDouwn -= Time.deltaTime;

			if (CountDouwn <= 0) {
				CountText.text="0";
				SceneManager.LoadScene (LoadSceneName);
				StartButton.SetActive (false);
				Level1Button.SetActive (true);
				Level2Button.SetActive (true);
				Level3Button.SetActive (true);
			}


				
		}

		//Debug.Log (LoadSceneNum);
	}





	public void LoadScene(){
		//SceneManager.LoadScene ("3D_MOT");
		flag = true;
	}

	public void LoadLevel1(){
		LoadSceneNum = 1;
		StartButton.SetActive (true);
		Level1Button.SetActive (false);
		Level2Button.SetActive (false);
		Level3Button.SetActive (false);
		CountText.text ="5";

	}

	public void LoadLevel2(){
		LoadSceneNum = 2;
		StartButton.SetActive (true);
		Level1Button.SetActive (false);
		Level2Button.SetActive (false);
		Level3Button.SetActive (false);
		CountText.text ="5";

	}

	public void LoadLevel3(){
		LoadSceneNum = 3;
		StartButton.SetActive (true);
		Level1Button.SetActive (false);
		Level2Button.SetActive (false);
		Level3Button.SetActive (false);
		CountText.text ="5";

	}
		
}
