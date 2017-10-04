using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCollisionCollor : MonoBehaviour {

	public List<string> _colArray;
	public List<Vector3> _colPosition=null; 
	private string _mixCol;
	[SerializeField]
	private List<GameObject> ColorBall;
//	[SerializeField]
//	private int _ballCount = 5;
//	[SerializeField]
//	private int _ballMax = 5;


	// Use this for initialization
	void Start () {
		//_ballCount = this.transform.childCount;
		
	}
	
	// Update is called once per frame
	void Update () {


		if (_colArray.Contains ("Blue") && _colArray.Contains ("Red")) {
			
			Vector3 pos = (_colPosition [0] + _colPosition [1]) / 2;
			Debug.Log (_colArray[0]);
			Debug.Log ("Create Purple");
			_colArray.Clear();
			Debug.Log (pos);
			Instantiate (ColorBall[0], pos, Quaternion.identity);
			_colPosition.Clear ();

		} else if (_colArray.Contains ("Red") && _colArray.Contains ("White")) {

			Vector3 pos = (_colPosition [0] + _colPosition [1]) / 2;
			Debug.Log ("Create Pink");
			_colArray.Clear();
			Instantiate (ColorBall[4], pos, Quaternion.identity);
			_colPosition.Clear ();

		} else if (_colArray.Contains ("Blue") && _colArray.Contains ("White")) {

			Vector3 pos = (_colPosition [0] + _colPosition [1]) / 2;
			Debug.Log ("Create SkyBlue");
			_colArray.Clear();
			Instantiate (ColorBall[2], pos, Quaternion.identity);
			_colPosition.Clear ();
		}



	}
		
}
