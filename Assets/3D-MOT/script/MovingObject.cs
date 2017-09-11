using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {


	[SerializeField]
	public float INIT_SPEED = 50f;
	[SerializeField]
	private int _maxRotateRange = 180;


	// Use this for initialization
	void Start () {
		shotBall();

	}
	
	// Update is called once per frame
	void Update () {



	}


	void OnCollisionEnter(Collision collision) {
		//this.transform.transform = GetComponent<Rigidbody> ().velocity.normalized * 10;
	}

	void shotBall() {
		Vector2 vel = Vector2.zero;
		vel=new Vector2(Random.Range(0, _maxRotateRange), Random.Range(0, -_maxRotateRange));

		this.transform.LookAt(vel);
		GetComponent<Rigidbody> ().velocity = transform.forward * INIT_SPEED;
	}


//	void OnCollisionEnter(Collision collision){
////		Destroy(collision.gameObject);
////		Destroy(this.gameObject);
//
//	}
}
