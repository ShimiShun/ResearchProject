using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ob_move : MonoBehaviour {


	public GameObject obj;
	Vector3 xm_pos, ym_pos, zm_pos;

	public float INIT_DEGREE = 80f;
	public float INIT_SPEED = 150f;

	// Use this for initialization
	void Start () {
		shotBall();
	}
	
	// Update is called once per frame
	void Update () {

//		xm_pos = transform.localPosition;
//		xm_pos.x += 0.2f;
//		this.transform.localPosition = xm_pos;  // 移動を更新
//
//		ym_pos = transform.localPosition;
//		ym_pos.y += 0.02f;
//		this.transform.localPosition = ym_pos;  // 移動を更新

//		zm_pos = transform.localPosition;
//		zm_pos.z += 0.01f;
//		this.transform.localPosition = zm_pos;  // 移動を更新

	}

	void shotBall() {
		Vector3 vel = Vector3.zero;
		vel.x = INIT_SPEED*Mathf.Cos(INIT_DEGREE*Mathf.PI/180f);
		//vel.y = INIT_SPEED*Mathf.Sin(INIT_DEGREE*Mathf.PI/180f);
		GetComponent<Rigidbody>().velocity = vel;
	}


//	void OnCollisionEnter(Collision collision){
////		Destroy(collision.gameObject);
////		Destroy(this.gameObject);
//
//	}
}
