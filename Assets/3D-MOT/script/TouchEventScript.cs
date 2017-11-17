using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class TouchEventScript : MonoBehaviour
{


	ListCollisionCollor DelBall;
	public bool DelFlag = false;
	[SerializeField]
	private Text PointText;
	public float PointCount = 0;
	//private int a = 0;
	public int MissTouchCount = 0;

	private float Timer = 0;
	private float Timer2 = 0;

	[SerializeField]
	private float MaxTime = 10;

	public bool _lvl1 = false;
	public bool _lvl2 = false;
	public bool _lvl3 = false;

	[SerializeField]
	private Text FinishText;

	public static string StudentNumber;
	public static string Gender;
	private string data;

	private int PurpleNum;
	private int PinkNum;
	private int SkyblueNum;
	private int SuccessCount;

	// Use this for initialization
	void Start ()
	{
		DelBall = GameObject.Find ("FirstMoveBall").GetComponent<ListCollisionCollor> ();

		StudentNumber = StartScript.Numbers;
		Gender = StartScript.Gender;

		//PointText.transform.position = Vector2 (Screen.width - 50, Screen.height - 50);

	}
	
	// Update is called once per frame
	void Update ()
	{
		Timer += Time.deltaTime;
		Timer2 += Time.deltaTime;

		if (Timer >= MaxTime) {
			Timer-=MaxTime;
		}
		//Debug.Log (Timer);

		
		if(Input.GetMouseButtonDown(0)){

			if (DelBall.CreatedBall.Count == 0) {
				PointCount = PointCount - 1;
				MissTouchCount++;
			}

			else {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit)) {
					var selectedObjTag = hit.collider.gameObject.tag;               
					//Debug.Log ("name=" + selectedObjTag);

//					if (selectedObjTag == "Purple" || selectedObjTag == "Skyblue" || selectedObjTag == "Pink") {
//						DelBall.CreatedBall.RemoveAt (0);
//						DelFlag = true;
//						//Debug.Log (true);
//					}




					if (_lvl1 == true) {
						if (selectedObjTag == "Purple") {
							//Destroy (hit.collider.gameObject);
							PointCount += 2;
							SuccessCount++;
							DelFlag = true;
							
						} else if (selectedObjTag == "Skyblue" || selectedObjTag == "Pink") {
							Destroy (hit.collider.gameObject);
							PointCount--;
							MissTouchCount++;
						}
					}


					if (_lvl2 == true) {
						if (selectedObjTag == "Skyblue"||selectedObjTag=="Pink") {
							//Destroy (hit.collider.gameObject);
							PointCount += 2;
							SuccessCount++;
							DelFlag = true;

						} else if (selectedObjTag == "Purple") {
							Destroy (hit.collider.gameObject);
							PointCount--;
							MissTouchCount++;
						}
					}

					if (_lvl3 == true) {
						if (selectedObjTag == "Purple"||selectedObjTag == "Skyblue" || selectedObjTag == "Pink") {
							//Destroy (hit.collider.gameObject);
							PointCount += 2;
							SuccessCount++;
							DelFlag = true;

						} 
					}

					DelBall.CreatedBall.RemoveAt (0);

				}
			}
		}


		PointText.text = "Score: " + PointCount.ToString ();

		if (Timer2 >= 60) {
			FinishText.text = "おわり！!";
		}
		
		if (Timer2 >= 65) {
//			
			if (_lvl1 == true) {
				PurpleNum = ListCollisionCollor.CountPurple;
				data = Gender + ", " + "score: " + PointCount.ToString () + ", " + "1色出現数数: "+PurpleNum.ToString() + ", " 
					+ "成功数: " + SuccessCount.ToString() + ", " + "お手つき: " + MissTouchCount.ToString () + ", " + "ノータッチミス" + CreatedObject.NoTouchCount.ToString(); 
			}

			if (_lvl2) {
				var total = ListCollisionCollor.CountSkyblue + PurpleNum + ListCollisionCollor.CountPink;
				data = Gender + ", " + "score: " + PointCount.ToString () + ", " + "2色出現数: " + total.ToString() + ", " 
					+ "成功数: " + SuccessCount.ToString() + ", " + "お手つき: " + MissTouchCount.ToString () + ", " + "ノータッチミス" + CreatedObject.NoTouchCount.ToString();
			}

			if (_lvl3) {
				var total = ListCollisionCollor.CountSkyblue + PurpleNum + ListCollisionCollor.CountPink + ListCollisionCollor.CountPurple;
				data = Gender + ", " + "score: " + PointCount.ToString () + ", " + "3色出現数: " + total.ToString() + ", " 
					+ "成功数: " + SuccessCount.ToString() + ", " + "お手つき: " + MissTouchCount.ToString () + ", " + "ノータッチミス" + CreatedObject.NoTouchCount.ToString();
			}


			textSave (data);
			SceneManager.LoadScene ("StartScene"); 
		}

		

	}


	public void textSave(string txt){
		var FileName="../"+StudentNumber+".txt";
		StreamWriter sw = new StreamWriter(FileName,true); //true=追記 false=上書き
		sw.WriteLine(txt);
		sw.Flush();
		sw.Close();
	}

		
}
