using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class unitSpawnManager : MonoBehaviour {

	public AudioSource audio1, audio2, finalBossAudio;
	public GameObject type1, type2, type3, type4, finalBoss, spawnObj, unitSpawner1, unitSpawner2, unitObj, go, go2;
	public bool spawnType1 = false, spawnType2 = true, waveEnd = false;
	
	public float spawnTime, waveTime;
	public int headCount1, headCount2, waveIndex, enemyPerWave;
	public Button bossReport;

	int randNum2, randNum3;
	
	void Start() {
		headCount1 = 5;
		headCount2 = 5;
		spawnTime = 4f;
		waveIndex = 0;
		//waveIndex = 5;

		waveEnd = false;
		waveTime = 20f;
		//waveTime = -1f;
	}
	
	void selectPath(GameObject go, GameObject spawnPos) {
		
		int randNum;
		
		if(spawnPos.name == "damaged_Battery_small_06") {
			randNum = Random.Range(0, 2);
			if(randNum == 0) {
				go.GetComponent<wayPointForEnemy>().enabled = true;
			}
			else if(randNum == 1) {
				go.GetComponent<wayPointForEnemy4>().enabled = true;
			}
		}
		else if(spawnPos.name == "damaged_Battery_small_05") {
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

		if(waveEnd == true) {
			waveTime -= Time.deltaTime;
		}

		if(waveIndex == 0) {
			spawnTime -= Time.deltaTime;
			if(spawnTime <= 0 && headCount1 > 0) {
				go = (GameObject)Instantiate(type1, unitSpawner1.transform.position, type1.transform.rotation);
				selectPath(go, unitSpawner1);
				spawnTime = 4f;
				headCount1--;
			}
			if(headCount1 <= 0) {
				waveIndex++;
				headCount1 = 5;
				waveEnd = true;
				waveTime = 15f;
			}
		}
		else if(waveIndex == 1 && waveTime <= 0) {
			waveEnd = false;
			spawnTime -= Time.deltaTime;
			if(spawnTime <= 0 && headCount1 > 0) {
				go = (GameObject)Instantiate(type1, unitSpawner2.transform.position, type1.transform.rotation);
				selectPath(go, unitSpawner2);
				spawnTime = 4f;
				headCount1--;
			}
			if(headCount1 <= 0) {
				waveIndex++;
				headCount1 = 10;
				waveEnd = true;
				waveTime = 15f;
			}
		}
		else if(waveIndex == 2 && waveTime <= 0) {
			waveEnd = false;
			spawnTime -= Time.deltaTime;
			if(spawnTime <= 0 && headCount1 > 0) {
				go = (GameObject)Instantiate(type2, unitSpawner1.transform.position, type2.transform.rotation);
				selectPath(go, unitSpawner1);
				spawnTime = 4f;
				headCount1--;
			}
			if(headCount1 <= 0) {
				waveIndex++;
				headCount1 = 10;
				waveEnd = true;
				waveTime = 15f;
			}
		}
		else if(waveIndex == 3 && waveTime <= 0) {
			waveEnd = false;
			spawnTime -= Time.deltaTime;
			if(spawnTime <= 0 && headCount1 > 0) {
				go = (GameObject)Instantiate(type3, unitSpawner2.transform.position, type3.transform.rotation);
				selectPath(go, unitSpawner2);
				spawnTime = 4f;
				headCount1--;
			}
			if(headCount1 <= 0) {
				waveIndex++;
				headCount1 = 15;
				waveEnd = true;
				waveTime = 30f;
			}
		}
		else if(waveIndex > 3 && waveIndex < 5 && waveTime <= 0) {
			waveEnd = false;
			spawnTime -= Time.deltaTime;
			if(spawnTime <= 0 && headCount1 > 0) {
				randNum2 = Random.Range(0, 4);

				if(randNum2 == 0) {
					spawnObj = type1;
				}
				else if (randNum2 == 1) {
					spawnObj = type2;
				}
				else if (randNum2 == 2) {
					spawnObj = type3;
				}
				else if (randNum2 == 3) {
					spawnObj = type4;
				}

				randNum3 = Random.Range(0, 2);

				if(randNum3 == 0) {
					unitObj = unitSpawner1;
				}
				else if (randNum3 == 1) {
					unitObj = unitSpawner2;
				}

				go = (GameObject)Instantiate(spawnObj, unitObj.transform.position, spawnObj.transform.rotation);
				selectPath(go, unitObj);
				spawnTime = 4f;
				headCount1--;
			}
			if(headCount1 <= 0) {
				waveIndex++;
				headCount1 = 10;
				waveEnd = true;
				waveTime = 15f;
			}
		}

		else if(waveIndex == 5 && waveTime <= 0) {
			audio1.Stop();
			audio2.Stop();
			finalBossAudio.enabled = true;
			finalBossAudio.Play();
			bossReport.gameObject.SetActive (true);
			Time.timeScale = 0;

			go = (GameObject)Instantiate(finalBoss, unitSpawner1.transform.position, finalBoss.transform.rotation);
			//go2 = (GameObject)Instantiate(finalBoss, unitSpawner2.transform.position, finalBoss.transform.rotation);
			go.GetComponent<wayPointForEnemy2>().enabled = true;
			//selectPath(go, unitSpawner1);
			//selectPath(go2, unitSpawner2);

			waveIndex++;
			//waveTime = 15f;
			waveTime = 0f;

			//spawnTime = 4f;
			//headCount1--;
		}
		else if(waveIndex == 6 && waveTime <= 0) {
			waveEnd = false;
			spawnTime -= Time.deltaTime;
			if(spawnTime <= 0 && headCount1 > 0) {
				go2 = (GameObject)Instantiate(type1, unitSpawner1.transform.position, type1.transform.rotation);
				selectPath(go2, unitSpawner1);
				spawnTime = 4f;
				headCount1--;
			}
			if(headCount1 <= 0) {
				//waveIndex++;
				headCount1 = 10;
				waveEnd = true;
				waveTime = 15f;
			}
		}

	}

	 


	public void reportGone() {
		bossReport.gameObject.SetActive (false);
		if(go.GetComponent<wayPointForEnemy2>().enabled == true) {
			go.GetComponent<wayPointForEnemy2>().speed = 2.5f;
		}
		else if(go.GetComponent<wayPointForEnemy3>().enabled == true) {
			go.GetComponent<wayPointForEnemy3>().speed = 2.5f;
		}
		Time.timeScale = 1;
	}

}
