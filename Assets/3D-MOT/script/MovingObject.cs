using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{


	[SerializeField]
	public float INIT_SPEED = 50f;
	[SerializeField]
	private int _maxRotateRange = 180;
	[SerializeField]
	private float _collValue = 0.5f;

	private GameObject _parentBall;
	ListCollisionCollor colliderParent;

	// Use this for initialization
	void Start ()
	{
		_parentBall = GameObject.Find ("FirstMoveBall");
		colliderParent = _parentBall.GetComponent<ListCollisionCollor> ();
		shotBall ();

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
			Debug.Log (random);
			if (random < _collValue) {
				colliderParent._colArray.Add (collision.gameObject.tag);
				colliderParent._colPosition.Add (this.transform.position);
			}
				
		}

	}
}
