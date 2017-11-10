using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{


	[SerializeField]
	public float INIT_SPEED = 20f;
	[SerializeField]
	private int _maxRotateRange = 360;
	private float _collValue = 0.3f;
	private GameObject _parentBall;
	ListCollisionCollor colliderParent;

	private float _timeCount = 0;
	private int rot = 1;



	// Use this for initialization
	void Start ()
	{
		_parentBall = GameObject.Find ("FirstMoveBall");
		colliderParent = _parentBall.GetComponent<ListCollisionCollor> ();
		shotBall ();

	}

	void Update(){

		_timeCount += Time.deltaTime;
		//Debug.Log(_timeCount);
		if (_timeCount % 10 <= 0.1) {
			
			GetComponent<Rigidbody> ().velocity = transform.forward*INIT_SPEED*rot;
		}


		if (_timeCount >= 60)
			this.GetComponent<Rigidbody> ().velocity = Vector3.zero;


	}



	void shotBall ()
	{
		Vector2 vel = Vector2.zero;
		vel = new Vector2 (Random.Range (0, _maxRotateRange), Random.Range (0, -_maxRotateRange));

		this.transform.LookAt (vel);
		GetComponent<Rigidbody> ().velocity = transform.forward * INIT_SPEED;
	}


	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag != "Wall") {
			
			var random = Random.value;
			//Debug.Log (random);
			if (random < _collValue) {
				colliderParent._colArray.Add (collision.gameObject.tag);
				colliderParent._colPosition.Add (this.transform.position);
			}
		}

		if (collision.gameObject.name == "wallLeft") {
			rot = 1;
		}

		if (collision.gameObject.name == "wallRight") {
			rot = -1;
		}

	}


		
}
