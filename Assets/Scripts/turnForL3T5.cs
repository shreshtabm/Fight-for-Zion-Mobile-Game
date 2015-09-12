using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class turnForL3T5 : MonoBehaviour {

	Vector3 targetDir, newDir;
	public List<GameObject> enemyList = new List<GameObject>();
	public Collider[] enemyWithinSearch;
	public GameObject target;
	public float burnTime = 4f, checkTime = 0f;
	

	void Start () {
		burnTime = 4f;
		checkTime = 0f;
	}

	void searchEnemy() {
		enemyWithinSearch = Physics.OverlapSphere (this.transform.position, 60);
		if (enemyWithinSearch == null) {
			return;
		}
		for(int i = 0; i < enemyWithinSearch.Length; i++) {
			if(enemyWithinSearch[i].gameObject.tag == "Enemy") {
				enemyList.Add(enemyWithinSearch[i].gameObject);
			}
		}
		checkTime = 2f;
	}

	bool checkIfWithin(GameObject target) {
		if(Vector3.Distance(this.transform.position, target.transform.position) < 60) {
			return true;
		}
		else {
			return false;
		}
	}


	
	void Update () {
		if(checkTime <= 0) {
			enemyList.Clear();
			searchEnemy();
		}
		else if(checkTime > 0) {
			//burnTime = 2f;
			checkTime -= Time.deltaTime;
			if(enemyList.Count > 0) {
				if(enemyList[0] != null) {
					target = enemyList[0];
					targetDir = target.transform.position - transform.position;
					targetDir.y = transform.forward.y;
					newDir = Vector3.RotateTowards (transform.forward, targetDir, 10*Time.deltaTime, 0.0F);
					transform.rotation = Quaternion.LookRotation (newDir);

					this.transform.GetChild(0).gameObject.SetActive(true);
					this.GetComponent<AudioSource>().enabled = true;
					if(checkIfWithin(enemyList[0]) == false) {
						checkTime = 0;
					}
				}
			}

		}


		if(burnTime > 0) {
			burnTime -= Time.deltaTime;
			this.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
			if(this.transform.GetChild(1).gameObject != null) {
				this.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
			}
		}
		else if(burnTime < 0) {
			this.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
			if(this.transform.GetChild(1).gameObject != null) {
				this.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
			}
			burnTime = 4f;
		}



	}

}

