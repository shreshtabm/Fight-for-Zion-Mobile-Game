using UnityEngine;
using System.Collections;

public class detectTowerEnter : MonoBehaviour {

	public GameObject towerManager2, canvas0, img0;
	public bool ifRotate, ifTowerAlready, startSwipe;
	public Vector3 finalPos;
	float countToEnableSwipe;

	void Start () {
		startSwipe = false;
		countToEnableSwipe = 3f;
		towerManager2 = GameObject.Find ("towerManager");
		canvas0 = this.transform.GetChild (0).gameObject;
		img0 = canvas0.transform.GetChild (0).gameObject;
		ifRotate = false;
		ifTowerAlready = false;
	}
	
	void OnTriggerEnter(Collider c){

		if(this.GetComponent<checkIfSpawnTower>().ifTowerAlready == false) {
			//if (c.name == "tower1(Clone)" || c.name == "tower1") {
			if (c.tag == "Tower") {
				//Debug.Log("c.gameObject.name = " + c.gameObject.name);
				//GameObject.Destroy (c.gameObject);
				towerManager2.GetComponent<towerManagement>().blink = false;
				finalPos = new Vector3(this.transform.position.x, this.transform.position.y+3, this.transform.position.z);
				towerManager2.GetComponent<towerManagement>().target2.transform.position = finalPos;
				towerManager2.GetComponent<towerManagement>().ifMoveable = false;
				towerManager2.GetComponent<towerManagement>().hitMove = false;

				towerManager2.GetComponent<towerManagement>().startSpawn = false;
				this.GetComponent<checkIfSpawnTower>().ifTowerAlready = true;
				canvas0.SetActive(false);
				towerManager2.GetComponent<towerManagement>().disablePossiblePlane();
				//Camera.main.GetComponent<swipeFun>().enabled = true;
				startSwipe = true;
			}
		}
			
		
	}

	void Update () {
		if(ifRotate == true) {
			img0.transform.RotateAround (img0.transform.parent.position, img0.transform.parent.forward, 60* Time.deltaTime);
		}

		if(startSwipe == true) {
			countToEnableSwipe -= Time.deltaTime;
		}

		if(countToEnableSwipe <= 0) {
			Camera.main.GetComponent<swipeFun>().enabled = true;
			startSwipe = false;
			countToEnableSwipe = 3f;
		}

	}
}
