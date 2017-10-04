using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {


	[SerializeField]
	public float INIT_SPEED = 50f;
	[SerializeField]
	private int _maxRotateRange = 180;

	private GameObject _parentBall;

	int a=0;

	ListCollisionCollor colliderParent;

	// Use this for initialization
	void Start () {
		_parentBall = GameObject.Find ("FirstMoveBall");
		colliderParent = _parentBall.GetComponent<ListCollisionCollor>();
		shotBall();

	}



	void shotBall() {
		Vector2 vel = Vector2.zero;
		vel=new Vector2(Random.Range(0, _maxRotateRange), Random.Range(0, -_maxRotateRange));

		this.transform.LookAt(vel);
		GetComponent<Rigidbody> ().velocity = transform.forward * INIT_SPEED;
	}


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag != "Wall") {
			

				colliderParent._colArray.Add (collision.gameObject.tag);
				colliderParent._colPosition.Add (this.transform.position);

				//Destroy (this.gameObject);

				Debug.Log (collision.gameObject.tag);
			}



	}
}
