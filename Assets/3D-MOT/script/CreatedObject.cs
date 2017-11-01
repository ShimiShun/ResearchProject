using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedObject : MonoBehaviour
{


	[SerializeField]
	private float _timeSpeed = 2;
	[SerializeField]
	private float _scaleUpdate = 30;
	[SerializeField]
	private float _timeCount = 0;
	[SerializeField]
	private float _maxCount = 2;
	[SerializeField]
	private AudioClip[] _tapSound;
	public AudioClip clip;
	private AudioSource _audio;

	TouchEventScript TouchFlag;
	AudioSoundPlay sound;
	private float point;

	// Use this for initialization
	void Start ()
	{
		TouchFlag = GameObject.Find ("FirstMoveBall").GetComponent<TouchEventScript> ();
		sound = GameObject.Find ("AudioPlay").GetComponent<AudioSoundPlay> ();
		point = TouchFlag.PointCount;

		_audio = gameObject.GetComponent<AudioSource> ();
		clip=_tapSound[Random.Range(0,_tapSound.Length)];

	}
	
	// Update is called once per frame
	void Update ()
	{

		this.transform.localScale = new Vector3 (Mathf.PingPong (Time.time * _timeSpeed, _scaleUpdate)
			, Mathf.PingPong (Time.time * _timeSpeed, _scaleUpdate), Mathf.PingPong (Time.time * _timeSpeed, _scaleUpdate));

		_timeCount += Time.deltaTime;//出現してからの時間を計測



		if (TouchFlag.DelFlag == true) {
			TouchFlag.DelFlag = false;
			point = point + 2;
			TouchFlag.PointCount = point;
			sound._soundPlay.PlayOneShot (clip);//消えたときの効果音再生
			Destroy (this.gameObject);

		}
		else if (_timeCount >= _maxCount) {
			point--;
			TouchFlag.PointCount = point;
			Destroy (this.gameObject);

		}

	}
		
}
