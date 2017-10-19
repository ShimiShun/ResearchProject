using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;


public class TouchEventScript : MonoBehaviour {

	private Controller controller = new Controller ();


	// Use this for initialization
	void Start () {
		
//		controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
//		controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
//		controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
		controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
	}
	
	// Update is called once per frame
	void Update () {

		Frame frame = controller.Frame ();
		GestureList leap_gestures = frame.Gestures ();

		if ( frame.Fingers[0].IsValid ) {
			for ( int i = 0 ; i < leap_gestures.Count ; i++ ) {
				// ジェスチャー結果取得＆表示
				Gesture gesture = leap_gestures[i];
				switch ( gesture.Type ) {
//				case Gesture.GestureType.TYPECIRCLE:
//					var circleGesture = new CircleGesture(gesture);
//					printGesture("Circle");
//					break;
//				case Gesture.GestureType.TYPEKEYTAP:
//					var keytapGesture = new KeyTapGesture(gesture);
//					printGesture("KeyTap");
//					break;
//				case Gesture.GestureType.TYPESCREENTAP:
//					var screenTapGesture = new ScreenTapGesture(gesture);
//					Debug.Log("ScreenTap");
//					break;
				case Gesture.GestureType.TYPE_SWIPE:
					var swipeGesture = new SwipeGesture(gesture);
					Debug.Log("Swipe");
					break;
				default:
					break;
				}
			}
		}
	}
		
}
