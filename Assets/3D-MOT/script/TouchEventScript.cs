using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using UnityEngine.UI;


public class TouchEventScript : MonoBehaviour
{

	private Controller controller = new Controller ();
	ListCollisionCollor DelBall;
	public bool DelFlag = false;
	[SerializeField]
	private Text PointText;
	public float PointCount = 0;
	private int a = 0;

	// Use this for initialization
	void Start ()
	{

		DelBall = GameObject.Find ("FirstMoveBall").GetComponent<ListCollisionCollor> ();
		//PointText.transform.position = Vector2 (Screen.width - 50, Screen.height - 50);

//		controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
//		controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
//		controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
		controller.EnableGesture (Gesture.GestureType.TYPESWIPE);
	}
	
	// Update is called once per frame
	void Update ()
	{


		Frame frame = controller.Frame ();
		GestureList leap_gestures = frame.Gestures ();

//		if ( frame.Fingers[0].IsValid ) {
//			for ( int i = 0 ; i < leap_gestures.Count ; i++ ) {
//				// ジェスチャー結果取得＆表示
//				Gesture gesture = leap_gestures[i];
//				switch ( gesture.Type ) {
//				case Gesture.GestureType.TYPECIRCLE:
//					var circleGesture = new CircleGesture(gesture);
//					//printGesture("Circle");
//					break;
//				case Gesture.GestureType.TYPEKEYTAP:
//					var keytapGesture = new KeyTapGesture(gesture);
//					//printGesture("KeyTap");
//					break;
//				case Gesture.GestureType.TYPESCREENTAP:
//					var screenTapGesture = new ScreenTapGesture(gesture);
//					Debug.Log("ScreenTap");
//					break;
//				case Gesture.GestureType.TYPE_SWIPE:
//					var swipeGesture = new SwipeGesture(gesture);
//					Debug.Log("Swipe");
//					break;
//				default:
//					break;
//				}
//			}
//		}


		//for (int i = 0; i < leap_gestures.Count; i++) {

			
		Gesture gesture = leap_gestures [0];

		// ジェスチャーがスワイプだった場合
		if (gesture.Type == Gesture.GestureType.TYPESWIPE) {
			SwipeGesture Swipe = new SwipeGesture (gesture);
			// スワイプ方向
			Vector SwipeDirection = Swipe.Direction;
			// 0より小さかった場合
			if (SwipeDirection.y < 0 && a == 0) {
				// Downのログを表示
				Debug.Log ("Down");

				if (DelBall.CreatedBall.Count == 0) {
					PointCount = PointCount - 1;
				} else {
					
					DelBall.CreatedBall.RemoveAt (0);
					DelFlag = true;
				}
					
				a++;

				// 0より大きかった場合
			} else if (SwipeDirection.y > 0) {
				// Upのログを表示
				//Debug.Log ("Up");

				a = 0;
			}
			//}
		}
		//Debug.Log (PointCount);

		if (PointCount < -10f) {
			PointCount = 0;
		}

		PointText.text = "Score: " + PointCount.ToString ();

	}
		
}
