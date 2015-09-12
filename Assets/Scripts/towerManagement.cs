using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class towerManagement: MonoBehaviour {

	public GameObject tower0, tower4, tower5, tower6, spawnedObj, spawnTower, canvas0, img0;
	public Vector3 touchPos;
	public bool ifFixLoc, startSpawn, ifMoveable, blink, circleDisappear, hitMove;
	public GameObject target2, coinBar;
	Color origColor;
	float colorChangeTime;
	public Collider[] planeWithinSearch;
	List<GameObject> planeList = new List<GameObject>();


	void Start() {
		planeList.Clear();
		searchPlane ();
		hitMove = false;
		circleDisappear = false;
		ifFixLoc = false;
		startSpawn = false;
		ifMoveable = false;
		blink = false;
		colorChangeTime = 0;
		coinBar = GameObject.FindGameObjectWithTag ("CoinBar");

	}

	void searchPlane() {
		planeWithinSearch = Physics.OverlapSphere (this.transform.position, 250);
		if (planeWithinSearch == null) {
			return;
		}
		for(int i = 0; i < planeWithinSearch.Length; i++) {
			if(planeWithinSearch[i].gameObject.name == "planeForTowerTest") {
				planeList.Add(planeWithinSearch[i].gameObject);
			}
		}
	}

	public void checkPossiblePlane(List<GameObject> planeList) {
		for(int i = 0; i < planeList.Count; i++) {
			if(planeList[i].GetComponent<checkIfSpawnTower>().ifTowerAlready == false) {
				planeList[i].transform.GetChild (0).gameObject.SetActive(true);
				planeList[i].GetComponent<detectTowerEnter>().ifRotate = true;
			}
		}
	}

	public void disablePossiblePlane() {
		for(int i = 0; i < planeList.Count; i++) {
			planeList[i].transform.GetChild (0).gameObject.SetActive(false);
			planeList[i].GetComponent<detectTowerEnter>().ifRotate = false;
		}
	}


	public void selectTower(int tower_index) {
		if(tower_index == 0) {
			if(coinBar.GetComponent<UIBarScript>().NewValue >= 0.1f) {
				coinBar.GetComponent<UIBarScript>().NewValue -= 0.1f;
				target2 = (GameObject)Instantiate(tower0, new Vector3(300, 197, 256), tower0.transform.rotation);
				//target2.transform.localScale *= 2f;

				origColor = target2.renderer.material.color;
				startSpawn = true;
				blink = true;
				hitMove = true;
				checkPossiblePlane(planeList);
				Camera.main.GetComponent<swipeFun>().enabled = false;
			}
		}
		if(tower_index == 1) {
			if(coinBar.GetComponent<UIBarScript>().NewValue >= 0.2f) {
				coinBar.GetComponent<UIBarScript>().NewValue -= 0.2f;
				target2 = (GameObject)Instantiate(tower4, new Vector3(300, 197, 256), tower4.transform.rotation);
				//target2.transform.localScale *= 2f;
				origColor = target2.renderer.material.color;
				startSpawn = true;
				blink = true;
				hitMove = true;
				checkPossiblePlane(planeList);
				Camera.main.GetComponent<swipeFun>().enabled = false;
			}
		}
		if(tower_index == 2) {
			if(coinBar.GetComponent<UIBarScript>().NewValue >= 0.3f) {
				coinBar.GetComponent<UIBarScript>().NewValue -= 0.3f;
				target2 = (GameObject)Instantiate(tower5, new Vector3(300, 197, 256), tower5.transform.rotation);
				//target2.transform.localScale *= 2f;
				origColor = target2.renderer.material.color;
				startSpawn = true;
				blink = true;
				hitMove = true;
				checkPossiblePlane(planeList);
				Camera.main.GetComponent<swipeFun>().enabled = false;
			}
		}
		if(tower_index == 3) {
			if(coinBar.GetComponent<UIBarScript>().NewValue >= 0.4f) {
				coinBar.GetComponent<UIBarScript>().NewValue -= 0.4f;
				target2 = (GameObject)Instantiate(tower6, new Vector3(300, 197, 256), tower6.transform.rotation);
				//target2.transform.localScale *= 2f;
				origColor = target2.renderer.material.color;
				startSpawn = true;
				blink = true;
				hitMove = true;
				checkPossiblePlane(planeList);
				Camera.main.GetComponent<swipeFun>().enabled = false;
			}
		}

	}

	public void playFlowCtrl(int choice) {
		if(choice == 0) {
			Time.timeScale = 0;
		}
		if(choice == 1) {
			Time.timeScale = 1;
		}
		if(choice == 2) {
			//Application.LoadLevel("Menu");
			Application.LoadLevel("MainMenu");
		}
	}


	void Update() {
		if(target2 != null) {
			if(blink == true) {
				colorChangeTime += Time.deltaTime;
				if(colorChangeTime > 0.5 && colorChangeTime < 1) {
					target2.renderer.material.color = Color.red;
					for(int i = 0; i < target2.transform.childCount; i++) {
						if(target2.transform.GetChild(i).renderer != null) {
							target2.transform.GetChild(i).renderer.material.color = Color.red;
						}
					}
				}
				else if(colorChangeTime > 1) {
					target2.renderer.material.color = origColor;
					for(int i = 0; i < target2.transform.childCount; i++) {
						if(target2.transform.GetChild(i).renderer != null) {
							target2.transform.GetChild(i).renderer.material.color = origColor;
						}
					}
					colorChangeTime = 0;
				}
			}
			else if(blink == false) {
				target2.renderer.material.color = origColor;
				for(int i = 0; i < target2.transform.childCount; i++) {
					if(target2.transform.GetChild(i).renderer != null) {
						target2.transform.GetChild(i).renderer.material.color = origColor;
					}
				}
			}
		}

		if(startSpawn == true) {
			if (Input.touchCount > 0) {
				var touch = Input.GetTouch(0);
				if(touch.phase == TouchPhase.Began) {
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(touch.position);
					if (Physics.Raycast(ray, out hit)) {
						touchPos = hit.point;
						//if(hit.collider.gameObject.name == "tower1(Clone)") {
						if(hit.collider.gameObject.tag == "Tower" && hitMove == true) {
							ifMoveable = true;
						}
					}
				}
				
				else if(touch.phase == TouchPhase.Moved && ifMoveable == true) {

					RaycastHit hit2;
					Ray ray2 = Camera.main.ScreenPointToRay (touch.position);
					if(Physics.Raycast (ray2, out hit2)) {
						//touchPos.Set (hit2.point.x, 0, hit2.point.z);
						touchPos = hit2.point;
						touchPos.y = 6;
						target2.transform.position = touchPos;
					}

				}
				
				else if(touch.phase == TouchPhase.Ended) {

				}
			}
		}
	}

	
}

