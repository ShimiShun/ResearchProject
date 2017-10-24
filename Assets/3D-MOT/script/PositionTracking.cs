using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTracking : MonoBehaviour {

	[SerializeField]
	private GameObject _hand;
	[SerializeField]
	private List<GameObject> _colorBall;

	ListCollisionCollor _stackBalls;


	// Use this for initialization
	void Start () {
		_stackBalls = GameObject.Find ("FirstMoveBall").GetComponent<ListCollisionCollor> ();
		_colorBall = _stackBalls.CreatedBall;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
