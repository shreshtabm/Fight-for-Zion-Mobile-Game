using UnityEngine;
using System.Collections;

public class SPManagement : MonoBehaviour {

	public GameObject spawnedSuperPower, superPower, SPButton, superPower2, SPButton2;
	public bool spawnSP, ifMoveable, hitMove, ifFixLoc;
	public Vector3 SPTouchPos;
	Color origColor;


	void Start () {
		spawnSP = false;
		ifMoveable = false;
		hitMove = false;
		ifFixLoc = false;
	}

	public void selectSuperPower(int sp_index) {
		if(sp_index == 0) {
			//if(Coin_Management.coins >= 20) {
				spawnedSuperPower = (GameObject)Instantiate(superPower, new Vector3(319, 226, 254), superPower.transform.rotation);
				spawnedSuperPower.GetComponent<ParticleSystem>().startSize = 30;
				origColor = spawnedSuperPower.transform.GetChild(0).GetComponent<ParticleSystem>().startColor;
				spawnedSuperPower.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = Color.red;
				spawnSP = true;
				hitMove = true;
				SPButton.GetComponent<SP1TimeManager>().resetTime = true;
				//origColor = target2.renderer.material.color;
				//startSpawn = true;
				//blink = true;
				//checkPossiblePlane(planeList);
			//}
		}
		else if(sp_index == 1) {
			spawnedSuperPower = (GameObject)Instantiate(superPower2, new Vector3(319, 226, 254), superPower2.transform.rotation);
			spawnedSuperPower.GetComponent<ParticleSystem>().startSize = 30;
			origColor = spawnedSuperPower.transform.GetChild(0).GetComponent<ParticleSystem>().startColor;
			spawnedSuperPower.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = Color.red;
			spawnSP = true;
			hitMove = true;
			SPButton2.GetComponent<SP1TimeManager>().resetTime = true;
		}

	}

	void Update () {

		if(spawnSP == true) {
			if (Input.touchCount > 0) {
				var touch = Input.GetTouch(0);
				if(touch.phase == TouchPhase.Began) {
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(touch.position);
					if (Physics.Raycast(ray, out hit)) {
						SPTouchPos = hit.point;
						if(hit.collider.gameObject.tag == "SuperPower" && hitMove == true) {
							Camera.main.GetComponent<swipeFun>().enabled = false;
							ifMoveable = true;
						}
					}
				}
				
				else if(touch.phase == TouchPhase.Moved && ifMoveable == true) {
					hitMove = false;

					RaycastHit hit2;
					Ray ray2 = Camera.main.ScreenPointToRay (touch.position);
					if(Physics.Raycast (ray2, out hit2)) {
						//touchPos.Set (hit2.point.x, 0, hit2.point.z);
						SPTouchPos = hit2.point;
						SPTouchPos.y = 17;
						spawnedSuperPower.transform.position = SPTouchPos;
					}
					
				}
				
				else if(touch.phase == TouchPhase.Ended) {
					if(ifMoveable == true) {
						ifMoveable = false;
						ifFixLoc = true;
					}
					if(ifFixLoc == true) {
						Camera.main.GetComponent<swipeFun>().enabled = true;

						if(spawnedSuperPower.name == "ErekiBall2(Clone)") {
							spawnedSuperPower.GetComponent<ParticleSystem>().startSize = 120;
							spawnedSuperPower.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = origColor;
							ifFixLoc = false;
							//SPButton.GetComponent<SP1TimeManager>().resetTime = true;
							spawnedSuperPower.GetComponent<SP1_Gravity>().enabled = true;
							spawnSP = false;
						}
						else if(spawnedSuperPower.name == "ErekiBall(Clone)") {
							spawnedSuperPower.transform.GetChild(0).GetComponent<ParticleSystem>().startSize = 120;
							spawnedSuperPower.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = origColor;
							ifFixLoc = false;
							//SPButton2.GetComponent<SP1TimeManager>().resetTime = true;
							spawnedSuperPower.GetComponent<SP2_Crazy>().enabled = true;
							//spawnedSuperPower.GetComponent<SP2_Crazy>().enableFindPuppet = true;
							spawnSP = false;
						}


					}
				}
			}
		}

	}
}
