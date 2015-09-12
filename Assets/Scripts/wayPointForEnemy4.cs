﻿using UnityEngine;
using System.Collections;

public class wayPointForEnemy4 : MonoBehaviour {
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
		if(wayPointsTest4.stations != null && initTargetPos == true) {
			randNum = Random.Range(0, wayPointsTest4.wayPtNum);
			targetPos = wayPointsTest4.stations[stationIndex][randNum];
			initTargetPos = false;
		}
		
		targetDir = targetPos - transform.position;
		newDir = Vector3.RotateTowards (transform.forward, targetDir, speed*Time.deltaTime, 0.0F);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.position = Vector3.MoveTowards (transform.position, targetPos, speed*Time.deltaTime);
		if(ifCloseTarget(transform.position, targetPos) == true) {

			if(stationIndex < wayPointsTest4.stationNum - 1) {
				stationIndex++;
				randNum = Random.Range(0, wayPointsTest4.wayPtNum);
				if(stationIndex == wayPointsTest4.stationNum - 1) {
					randNum = 0;
				}
				targetPos = wayPointsTest4.stations[stationIndex][randNum];
			}
			
		}
		
	}

}



