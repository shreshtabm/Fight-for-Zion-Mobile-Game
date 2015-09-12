using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class camLookAround : MonoBehaviour {

	public AudioSource audio1;
	public AudioSource audio2;


	public GameObject enemy1, enemy2, zion;
	Vector3 originalPos, currentPos, touchPos, defaultLoc, enemy1Loc, enemy2Loc, zionLoc;
	List<Vector3> targetList = new List<Vector3>();
	List<GameObject> targetObjList = new List<GameObject>();

	bool startFocus, nextTarget, goBackToOrigFOV, checkIfOrigFOV, goBackToOrigForward;
	int targetIndex;

	void Start () {
		audio1.enabled = true;

		defaultLoc = Camera.main.transform.forward;
		targetIndex = 0;
		initBool ();
		collectTarget ();
		
//		this.transform.GetChild (0).gameObject.transform.LookAt (enemy1.transform);
//		enemy1Loc = this.transform.GetChild (0).gameObject.transform.forward;
//		Debug.Log ("enemy1Loc = " + enemy1Loc);
	}
	
	void collectTarget() {
		targetList.Clear();
		targetObjList.Clear ();
		
		targetObjList.Add(enemy1);
		this.transform.GetChild (0).gameObject.transform.LookAt (enemy1.transform);
		targetList.Add(this.transform.GetChild (0).gameObject.transform.forward);
		
		targetObjList.Add(enemy2);
		this.transform.GetChild (0).gameObject.transform.LookAt (enemy2.transform);
		targetList.Add(this.transform.GetChild (0).gameObject.transform.forward);
		
		targetObjList.Add(zion);
		this.transform.GetChild (0).gameObject.transform.LookAt (zion.transform);
		targetList.Add(this.transform.GetChild (0).gameObject.transform.forward);
	}
	
	
	void initBool() {
		startFocus = false;
		nextTarget = false;
		goBackToOrigFOV = false;
		checkIfOrigFOV = false;
		goBackToOrigForward = false;
		
	}

	void zoomInTarget(Vector3 targetLoc) {
		if(startFocus == false) {
			Camera.main.transform.forward = Vector3.MoveTowards (Camera.main.transform.forward, targetLoc, Time.deltaTime*0.5f);
		}
		if(Vector3.Distance(Camera.main.transform.forward, targetLoc) < 0.15f) { 
			if(targetObjList[targetIndex].transform.GetChild(0).gameObject != null) {
				targetObjList[targetIndex].transform.GetChild(0).gameObject.GetComponent<Canvas>().enabled = true;
			}			
			startFocus = true;
		}
		if(startFocus == true) {		enemy1.GetComponent<UnitSpawner2> ().enabled = false;
			enemy2.GetComponent<UnitSpawner2> ().enabled = false;
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,30,Time.deltaTime*0.5f);
		}
		if(camera.fieldOfView - 30 < 0.5) {
			goBackToOrigFOV = true;
		}
		if(goBackToOrigFOV == true) {
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,100,Time.deltaTime*0.5f);
			checkIfOrigFOV = true;
		}
		if(checkIfOrigFOV == true && (camera.fieldOfView > 60)) {
			if(targetObjList[targetIndex].transform.GetChild(0).gameObject != null) {
				targetObjList[targetIndex].transform.GetChild(0).gameObject.GetComponent<Canvas>().enabled = false;
			}
			Camera.main.transform.forward = Vector3.MoveTowards (Camera.main.transform.forward, defaultLoc, Time.deltaTime*0.5f);
			goBackToOrigForward = true;
		}
		
		if(Vector3.Distance(Camera.main.transform.forward, defaultLoc) < 0.01f && goBackToOrigForward == true) { 
			nextTarget = true;
			if(targetIndex == targetList.Count - 1) {
				//enemy1.GetComponent<UnitSpawner2> ().enabled = true;
				//enemy2.GetComponent<UnitSpawner2> ().enabled = true;
				this.GetComponent<unitSpawnManager>().enabled = true;
				audio1.enabled = false;
				audio2.enabled = true;
			}
		}
		
	}
	
	void Update () {
		if(nextTarget == false) {
			Debug.Log("targetIndex = " + targetIndex);
			zoomInTarget(targetList[targetIndex]);
		}
		else if(nextTarget == true) {
			if(targetIndex < targetList.Count - 1) {
				targetIndex++;
				initBool ();
			}
		}

	}
}
