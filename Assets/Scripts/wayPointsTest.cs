using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class wayPointsTest : MonoBehaviour {

	GameObject stationArr, stationArrChild;
	static public List<List<Vector3>> stations = new List<List<Vector3>>();
	static public int stationNum, wayPtNum;

	void Start () {

		stationArr = this.gameObject;
		stationNum = stationArr.transform.childCount;

		wayPtNum = stationArr.transform.GetChild (0).gameObject.transform.childCount;

		for(int i = 0; i < stationArr.transform.childCount; i++) {
			stationArrChild = stationArr.transform.GetChild(i).gameObject;
			stations.Add (new List<Vector3>());
			for(int j = 0; j < stationArrChild.transform.childCount; j++) {
				stations[i].Add (stationArrChild.transform.GetChild(j).transform.position);
			}
		}

	}



	void Update () {

	}
}
