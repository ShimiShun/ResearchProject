using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedObject : MonoBehaviour
{


	//	[SerializeField]
	//	private float _timeSpeed = 2;
	//	[SerializeField]
	//	private float _scaleUpdate = 30;
	[SerializeField]
	private float _timeCount = 0;
	[SerializeField]
	private float _maxCount = 2;
	[SerializeField]
	private AudioClip[] _tapSound;
	private AudioClip clip;
	private AudioSource _audio;

	TouchEventScript TouchFlag;
	AudioSoundPlay sound;
	private float point;

	[SerializeField]
	private float amplitude = 0.01f;
	// 振幅
	private int frameCnt = 0;
	// フレームカウント

	//Created Ballを強調するためだけのやつ
	void FixedUpdate ()
	{
		frameCnt += 1;
		if (10000 <= frameCnt) {
			frameCnt = 0;
		}
		if (0 == frameCnt % 2) {
			// 上下に振動させる（ふわふわを表現）
			float posYSin = Mathf.Sin (2.0f * Mathf.PI * (float)(frameCnt % 200) / (200.0f - 1.0f));
			float posXSin = Mathf.Cos (2.0f * Mathf.PI * (float)(frameCnt % 200) / (200.0f - 1.0f));
			iTween.MoveAdd (gameObject, new Vector3 (amplitude * posXSin, amplitude * posYSin, 0), 0.0f);
		}
	}


	// Use this for initialization
	void Start ()
	{
		TouchFlag = GameObject.Find ("FirstMoveBall").GetComponent<TouchEventScript> ();
		sound = GameObject.Find ("AudioPlay").GetComponent<AudioSoundPlay> ();


		_audio = gameObject.GetComponent<AudioSource> ();
		clip = _tapSound [Random.Range (0, _tapSound.Length)];

	}
	
	// Update is called once per frame
	void Update ()
	{

//		this.transform.localScale = new Vector3 (Mathf.PingPong (Time.time * _timeSpeed, _scaleUpdate)
//			, Mathf.PingPong (Time.time * _timeSpeed, _scaleUpdate), Mathf.PingPong (Time.time * _timeSpeed, _scaleUpdate));

		_timeCount += Time.deltaTime;//出現してからの時間を計測



		if (TouchFlag.DelFlag == true) {
			TouchFlag.DelFlag = false;
			sound._soundPlay.PlayOneShot (clip);//消えたときの効果音再生
			Destroy (this.gameObject);

		} else if (_timeCount >= _maxCount) {
			Debug.Log (true);
			if ((TouchFlag._lvl1 == true && this.gameObject.tag == "Purple")
			    || (TouchFlag._lvl2 == true && (this.gameObject.tag == "Skyblue" || this.gameObject.tag == "Pink"))
			    || (TouchFlag._lvl3 == true)) {
				point = TouchFlag.PointCount;
				point--;
				TouchFlag.PointCount = point;

			}
		
			Destroy (this.gameObject);
		}

	}
		
}
