using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;


public class TouchEventScript : MonoBehaviour {

	Controller controller;


	// Use this for initialization
	void Start () {
		
		controller = new Controller ();
		controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
	}
	
	// Update is called once per frame
	void Update () {

		Frame frame = controller.Frame ();
		GestureList leap_gestures = frame.Gestures ();

		for (int i = 0; i < leap_gestures.Count; i++) {

			Gesture gesture = leap_gestures [i];

			if (gesture.Type == Gesture.GestureType.TYPESWIPE) {
				SwipeGesture Swipe = new SwipeGesture (gesture);
				// スワイプ方向
				Vector SwipeDirection = Swipe.Direction;

				// 0より小さかった場合
				if (SwipeDirection.y < 0) {
					// Downのログを表示
					Debug.Log ("Down");

					// 0より大きかった場合
				} else if (SwipeDirection.y > 0) {
					// Upのログを表示
					Debug.Log ("Up");
				}

			}
		}
		
	}
}
