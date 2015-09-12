using UnityEngine;
using System.Collections;

public class UnitSpawner2 : MonoBehaviour {

	//public Transform target;
	//public GameObject Robot_Kyle;
	public GameObject type1, type2, go;
	public bool spawnType1 = false, spawnType2 = true, waveEnd = false;
	
	public float spawnTime, waveTime;
	float spawnTimeLeft = .1f, count;
	public int headCount, enemyPerWave;
	Vector3 spawnLocation;

	void Start() {
		spawnType1 = false;
		spawnType2 = true;
		spawnTime = 4;
		waveTime = 15;
		enemyPerWave = 5;
		spawnLocation = new Vector3 (transform.position.x, 0, transform.position.z);
	}

	void selectPath(GameObject go) {

		int randNum;

		if(this.name == "damaged_Battery_small_06") {
			randNum = Random.Range(0, 2);
			if(randNum == 0) {
				go.GetComponent<wayPointForEnemy>().enabled = true;
			}
			else if(randNum == 1) {
				go.GetComponent<wayPointForEnemy4>().enabled = true;
			}
		}
		else if(this.name == "damaged_Battery_small_05") {
			randNum = Random.Range(0, 2);
			if(randNum == 0) {
				go.GetComponent<wayPointForEnemy2>().enabled = true;
			}
			else if(randNum == 1) {
				go.GetComponent<wayPointForEnemy3>().enabled = true;
			}
		}
	}

	void Update () {
		count += Time.deltaTime;
		//Debug.Log ("spawnTime = " + spawnTime);
		if(count >= spawnTime && waveEnd == false) {
			//GameObject go = (GameObject)Instantiate(Robot_Kyle, transform.position, transform.rotation);
			if(spawnType1 == true) {
				//go = (GameObject)Instantiate(type1, transform.position, transform.rotation);
				go = (GameObject)Instantiate(type1, spawnLocation, transform.rotation);
				selectPath(go);
			}
			else if(spawnType2 == true) {
				//go = (GameObject)Instantiate(type2, transform.position, transform.rotation);
				go = (GameObject)Instantiate(type2, spawnLocation, transform.rotation);
				selectPath(go);

			}
			else {
				//go = (GameObject)Instantiate(type1, transform.position, transform.rotation);
				go = (GameObject)Instantiate(type1, spawnLocation, transform.rotation);
				selectPath(go);

			}
			go.tag = "Enemy";
			//go.GetComponent<AstarAI>().target = target;
			headCount++;
			count = 0;
		}
		
		if(headCount >= enemyPerWave) {
			waveEnd = true;
			enemyPerWave += 5;
		}
		
		if(count >= waveTime) {
			if(spawnType1 == true) {
				spawnType2 = true;
				spawnType1 = false;
			}
			else if(spawnType1 == false) {
				spawnType2 = false;
				spawnType1 = true;
			}
			headCount = 0;
			count = 0;
			waveEnd = false;
		}
		
		
	}
	
}