using UnityEngine;
using System.Collections;

public class UnitSpawner : MonoBehaviour {

	public Transform target;
	public GameObject Robot_Kyle;
	public GameObject type1, type2, go;
	public bool spawnType1 = false, spawnType2 = true, waveEnd = false;

	public float spawnTime, waveTime;
	float spawnTimeLeft = .1f, count;
	public int headCount, enemyPerWave;

	void Start() {
		spawnType1 = false;
		spawnType2 = true;
		spawnTime = 10;
		waveTime = 20;
		enemyPerWave = 5;
	}

	void Update () {
		count += Time.deltaTime;
		//Debug.Log ("spawnTime = " + spawnTime);
		if(count >= spawnTime && waveEnd == false) {
			//GameObject go = (GameObject)Instantiate(Robot_Kyle, transform.position, transform.rotation);
			if(spawnType1 == true) {
				go = (GameObject)Instantiate(type1, transform.position, transform.rotation);
			}
			else if(spawnType2 == true) {
				go = (GameObject)Instantiate(type2, transform.position, transform.rotation);
			}
			else {
				go = (GameObject)Instantiate(type1, transform.position, transform.rotation);
			}
			go.tag = "Enemy";
			go.GetComponent<AstarAI>().target = target;
			headCount++;
			count = 0;
			//spawnTimeLeft = spawnTime;
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
