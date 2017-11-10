using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TouchEventScript : MonoBehaviour
{


	ListCollisionCollor DelBall;
	public bool DelFlag = false;
	[SerializeField]
	private Text PointText;
	public float PointCount = 0;
	private int a = 0;
	private int MissTouchCount = 0;

	private float Timer = 0;
	private float Timer2 = 0;

	[SerializeField]
	private float MaxTime = 10;

	public bool _lvl1 = false;
	public bool _lvl2 = false;
	public bool _lvl3 = false;

	[SerializeField]
	private Text FinishText;

	// Use this for initialization
	void Start ()
	{
		DelBall = GameObject.Find ("FirstMoveBall").GetComponent<ListCollisionCollor> ();
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
							DelFlag = true;
							
						} else if (selectedObjTag == "Skyblue" || selectedObjTag == "Pink") {
							Destroy (hit.collider.gameObject);
							PointCount--;
						}
					}


					if (_lvl2 == true) {
						if (selectedObjTag == "Skyblue"||selectedObjTag=="Pink") {
							//Destroy (hit.collider.gameObject);
							PointCount += 2;
							DelFlag = true;

						} else if (selectedObjTag == "Purple") {
							Destroy (hit.collider.gameObject);
							PointCount--;
						}
					}

					if (_lvl3 == true) {
						if (selectedObjTag == "Purple"||selectedObjTag == "Skyblue" || selectedObjTag == "Pink") {
							//Destroy (hit.collider.gameObject);
							PointCount += 2;
							DelFlag = true;

						} 
					}

					DelBall.CreatedBall.RemoveAt (0);

				}
			}
		}


		PointText.text = "Score: " + PointCount.ToString ();

		if (Timer2 >= 60)
			FinishText.text = "おわり！!";
		else if (Timer2 >= 5)
			SceneManager.LoadScene ("StartScene"); 


	}
		
}
