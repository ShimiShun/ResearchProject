using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TouchEventScript : MonoBehaviour
{


	ListCollisionCollor DelBall;
	public bool DelFlag = false;
	[SerializeField]
	private Text PointText;
	public float PointCount = 0;
	private int a = 0;
	private int MissTouchCount = 0;

	// Use this for initialization
	void Start ()
	{

		DelBall = GameObject.Find ("FirstMoveBall").GetComponent<ListCollisionCollor> ();
		//PointText.transform.position = Vector2 (Screen.width - 50, Screen.height - 50);

	}
	
	// Update is called once per frame
	void Update ()
	{


//		// ジェスチャーがスワイプだった場合
//		if (gesture.Type == Gesture.GestureType.TYPESWIPE) {
//			SwipeGesture Swipe = new SwipeGesture (gesture);
//			// スワイプ方向
//			Vector SwipeDirection = Swipe.Direction;
//			// 0より小さかった場合
//			if (SwipeDirection.y < 0 && a == 0) {
//				// Downのログを表示
//				Debug.Log ("Down");
//
//				if (DelBall.CreatedBall.Count == 0) {
//					PointCount = PointCount - 1;
//				} else {
//					
//					DelBall.CreatedBall.RemoveAt (0);
//					DelFlag = true;
//				}
//					
//				a++;
//
//				// 0より大きかった場合
//			} else if (SwipeDirection.y > 0) {
//				// Upのログを表示
//				//Debug.Log ("Up");
//
//				a = 0;
//			}
//			//}
//		}
		//Debug.Log (PointCount);

		if(Input.GetMouseButtonDown(0)){

			if (DelBall.CreatedBall.Count == 0) {
				PointCount = PointCount - 1;
				MissTouchCount++;
			} 

			else {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit)) {
					var selectedGameObjectname = hit.collider.gameObject.name;               
					Debug.Log ("name=" + selectedGameObjectname);

					if (selectedGameObjectname == "B_purple(Clone)" || selectedGameObjectname == "B_skyblue(Clone)" || selectedGameObjectname == "B_pink(Clone)") {
						DelBall.CreatedBall.RemoveAt (0);
						DelFlag = true;
						Debug.Log (true);
					}

				}
			}
		}

		//use of open Lab
//		if (PointCount < -10f) {
//			PointCount = 0;
//		}

		PointText.text = "Score: " + PointCount.ToString ();

	}
		
}
