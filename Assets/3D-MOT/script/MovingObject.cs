using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {


	[SerializeField]
	public float INIT_SPEED = 50f;
	[SerializeField]
	private int _maxRotateRange = 180;
	[SerializeField]
	private GameObject _parentBall;

	ListCollisionCollor colliderParent;

	// Use this for initialization
	void Start () {
		
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

			Destroy (this.gameObject);

			Debug.Log(collision.gameObject.tag);
		}


	}
}
