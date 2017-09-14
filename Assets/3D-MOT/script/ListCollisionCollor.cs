using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCollisionCollor : MonoBehaviour {

	public List<string> _colArray;
	public List<Vector3> _colPosition=null; 
	private string _mixCol;
	[SerializeField]
	private List<GameObject> ColorBall;


	// Use this for initialization
	void Start () {

		
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

	}
		
}
