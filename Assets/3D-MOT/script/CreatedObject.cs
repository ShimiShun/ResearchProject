﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedObject : MonoBehaviour
{


	[SerializeField]
	private float _timeSpeed = 5;
	[SerializeField]
	private float _scaleUpdate = 10;
	[SerializeField]
	private float _timeCount = 0;
	[SerializeField]
	private float _maxCount = 5;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		this.transform.localScale = new Vector3 (Mathf.PingPong (Time.time * _timeSpeed, _scaleUpdate)
			, Mathf.PingPong (Time.time * _timeSpeed, _scaleUpdate), Mathf.PingPong (Time.time * _timeSpeed, _scaleUpdate));

		_timeCount += Time.deltaTime;//出現してからの時間を計測


		if (_timeCount >= _maxCount) {
			Destroy (this.gameObject);
		}

	}
		
}
