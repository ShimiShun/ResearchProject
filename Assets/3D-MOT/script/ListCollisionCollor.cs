using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCollisionCollor : MonoBehaviour {

	public List<string> _colArray;
	public List<Vector3> _colPosition=null; 
	private string _mixCol;
	[SerializeField]
	private List<GameObject> ColorBall;
	[SerializeField]
	private int _ballCount = 5;
	[SerializeField]
	private int _ballMax = 5;


	// Use this for initialization
	void Start () {
		_ballCount = this.transform.childCount;
		
	}
	
	// Update is called once per frame
	void Update () {


		if (_colArray.Contains ("Blue") && _colArray.Contains ("Red")) {
			
			Vector3 pos = (_colPosition [0] + _colPosition [1]) / 2;
			Debug.Log (_colArray[0]);
			Debug.Log ("Create Purple");
			_colArray.Clear();
			Debug.Log (pos);
			var obj = Instantiate (ColorBall[0], pos, Quaternion.identity);
			obj.transform.parent = this.transform;

		} else if (_colArray.Contains ("Blue") && _colArray.Contains ("Yellow")) {

			Debug.Log ("Create Green");
			_colArray.Clear();

		} else if (_colArray.Contains ("Blue") && _colArray.Contains ("White")) {

			Debug.Log ("Create SkyBlue");
			_colArray.Clear();

		}


		if (_ballCount <= _ballMax - 1) {
			for (int i = _ballCount; i < _ballMax; i++) {
//				GameObject obj = Instantiate (ColorBall[0], Vector3(5f,5f,-25f), Quaternion.identity);
//				obj.transform.parent = this.transform;

			}
		}
	}
		
}
