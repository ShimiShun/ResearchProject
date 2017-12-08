using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCollisionCollor : MonoBehaviour
{

	public List<string> _colArray;
//衝突した２つの球のタグを管理
	public List<Vector3> _colPosition = null;
	//衝突した２つの球の位置情報を管理
	public List<float> _colValue;
	private float RefValue = 0.3f;

	[SerializeField]
	private List<GameObject> ColorBall;
//生成される色の球を格納
	public List<GameObject> CreatedBall;


	public static int CountPurple;
	public static int CountSkyblue;
	public static int CountPink;

	// Use this for initialization
	void Start ()
	{
		//_ballCount = this.transform.childCount;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (_colValue.Count > 1) {

			if (_colValue [0] < RefValue || _colValue [1] < RefValue) {


				if ((_colArray.Contains ("Blue") && _colArray.Contains ("Red"))) {
				

					Vector3 pos = (_colPosition [0] + _colPosition [1]) / 2;
					//Debug.Log ("Create Purple");
					_colArray.Clear ();
					var a = Instantiate (ColorBall [0], pos, Quaternion.identity);
					_colPosition.Clear ();
					CreatedBall.Add (a);
					CountPurple++;
					_colValue.Clear ();

		
					

				} else if ((_colArray.Contains ("Red") && _colArray.Contains ("White"))) {
				
				
					Vector3 pos = (_colPosition [0] + _colPosition [1]) / 2;
					//Debug.Log ("Create Pink");
					_colArray.Clear ();
					var b = Instantiate (ColorBall [4], pos, Quaternion.identity);
					_colPosition.Clear ();
					CreatedBall.Add (b);
					CountPink++;
					_colValue.Clear ();
		


				} else if ((_colArray.Contains ("Blue") && _colArray.Contains ("White"))) {
				
				
					Vector3 pos = (_colPosition [0] + _colPosition [1]) / 2;
					//Debug.Log ("Create SkyBlue");
					_colArray.Clear ();
					var c = Instantiate (ColorBall [2], pos, Quaternion.identity);
					_colPosition.Clear ();
					CreatedBall.Add (c);
					CountSkyblue++;
					_colValue.Clear ();
				} else {
					_colValue.Clear ();
					_colPosition.Clear ();
				}
			} else {
				_colValue.Clear ();
				_colPosition.Clear ();
			}

				
		}


		for (int i = 0; i < CreatedBall.Count; i++) {

			if (CreatedBall [i] == null) {
				CreatedBall.RemoveAt (i);
			}
		}



	}
		
}
