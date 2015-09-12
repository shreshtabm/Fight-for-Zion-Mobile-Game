using UnityEngine;
using System.Collections;

public class wayPointForEnemy : MonoBehaviour {
	public Vector3 targetPos, targetDir, newDir;
	public int stationIndex, wayPointIndex;
	bool initTargetPos;
	int randNum;
	public float speed = 10f;

	void Start () {
		stationIndex = 0;
		wayPointIndex = 0;
		initTargetPos = true;
		speed = 10f;
	}

	bool ifCloseTarget (Vector3 currentPos, Vector3 targetPos) {
		if(Vector3.Distance(currentPos, targetPos) < 3) {
			return true;
		}
		return false;
	}

	void Update () {
		if(wayPointsTest.stations != null && initTargetPos == true) {
			randNum = Random.Range(0, wayPointsTest.wayPtNum);
			targetPos = wayPointsTest.stations[stationIndex][randNum];
			initTargetPos = false;
		}

		targetDir = targetPos - transform.position;
		newDir = Vector3.RotateTowards (transform.forward, targetDir, speed*Time.deltaTime, 0.0F);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.position = Vector3.MoveTowards (transform.position, targetPos, speed*Time.deltaTime);
		if(ifCloseTarget(transform.position, targetPos) == true) {
			if(stationIndex < wayPointsTest.stationNum - 1) {
				stationIndex++;
				randNum = Random.Range(0, wayPointsTest.wayPtNum);
				if(stationIndex == wayPointsTest.stationNum - 1) {
					randNum = 0;
				}
				targetPos = wayPointsTest.stations[stationIndex][randNum];
			}
//			else if(stationIndex == wayPointsTest.stationNum - 1) {
//
//			}
		}

	}
}
