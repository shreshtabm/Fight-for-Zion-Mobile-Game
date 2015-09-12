using UnityEngine;
using System.Collections;

public class crazy : MonoBehaviour {

	public GameObject explosion, spawnExplosion;
	public int currectIndex, newIndex, oldIndex;
	bool startCrazy = true, startSpawn = false;
	Vector3 explosionPos;
	float explosionTime, count;

	void Start () {
		startSpawn = false;
		startCrazy = true;
	}



	void OnTriggerEnter(Collider c) {

		if(c.tag == "Enemy" && startSpawn == true) {
			explosionPos = new Vector3(this.transform.position.x, this.transform.position.y+30, this.transform.position.z);
			spawnExplosion = (GameObject)Instantiate(explosion, explosionPos, transform.rotation);
			spawnExplosion.transform.parent = transform;
			this.GetComponent<healthOnEnemy>().currentHealth -= 20f;
			c.gameObject.GetComponent<healthOnEnemy>().currentHealth -= 20f;
		}

	}


	void Update () {
		if(this.GetComponent<wayPointForEnemy>().enabled == true && startCrazy == true) {
			startSpawn = true;
			currectIndex = this.GetComponent<wayPointForEnemy>().stationIndex;
			oldIndex = currectIndex;
			newIndex = currectIndex - 1;
			if(newIndex >= 0) {
				this.GetComponent<wayPointForEnemy>().stationIndex = newIndex;
				this.GetComponent<wayPointForEnemy>().targetPos = wayPointsTest.stations[newIndex][0];
			}
			else {
				GameObject.Destroy(this);
			}
			startCrazy = false;
		}

		if(this.GetComponent<wayPointForEnemy>().enabled == true && startCrazy == false) {
			currectIndex = this.GetComponent<wayPointForEnemy>().stationIndex;
			if(currectIndex == oldIndex) {

				newIndex = currectIndex - 2;
				oldIndex = oldIndex - 1;

				if(newIndex >= 0) {
					this.GetComponent<wayPointForEnemy>().stationIndex = newIndex;
					this.GetComponent<wayPointForEnemy>().targetPos = wayPointsTest.stations[newIndex][0];
				}
				else {
					GameObject.Destroy(this.gameObject);
				}
			}
		}

		if(this.GetComponent<wayPointForEnemy2>().enabled == true && startCrazy == true) {
			startSpawn = true;
			currectIndex = this.GetComponent<wayPointForEnemy2>().stationIndex;
			oldIndex = currectIndex;
			newIndex = currectIndex - 1;
			if(newIndex >= 0) {
				this.GetComponent<wayPointForEnemy2>().stationIndex = newIndex;
				this.GetComponent<wayPointForEnemy2>().targetPos = wayPointsTest2.stations[newIndex][0];
			}
			else {
				GameObject.Destroy(this);
			}
			startCrazy = false;
		}
		
		if(this.GetComponent<wayPointForEnemy2>().enabled == true && startCrazy == false) {
			currectIndex = this.GetComponent<wayPointForEnemy2>().stationIndex;
			if(currectIndex == oldIndex) {
				
				newIndex = currectIndex - 2;
				oldIndex = oldIndex - 1;
				
				if(newIndex >= 0) {
					this.GetComponent<wayPointForEnemy2>().stationIndex = newIndex;
					this.GetComponent<wayPointForEnemy2>().targetPos = wayPointsTest2.stations[newIndex][0];
				}
				else {
					GameObject.Destroy(this.gameObject);
				}
			}
		}


		if(this.GetComponent<wayPointForEnemy3>().enabled == true && startCrazy == true) {
			startSpawn = true;
			currectIndex = this.GetComponent<wayPointForEnemy3>().stationIndex;
			oldIndex = currectIndex;
			newIndex = currectIndex - 1;
			if(newIndex >= 0) {
				this.GetComponent<wayPointForEnemy3>().stationIndex = newIndex;
				this.GetComponent<wayPointForEnemy3>().targetPos = wayPointsTest3.stations[newIndex][0];
			}
			else {
				GameObject.Destroy(this);
			}
			startCrazy = false;
		}
		
		if(this.GetComponent<wayPointForEnemy3>().enabled == true && startCrazy == false) {
			currectIndex = this.GetComponent<wayPointForEnemy3>().stationIndex;
			if(currectIndex == oldIndex) {
				
				newIndex = currectIndex - 2;
				oldIndex = oldIndex - 1;
				
				if(newIndex >= 0) {
					this.GetComponent<wayPointForEnemy3>().stationIndex = newIndex;
					this.GetComponent<wayPointForEnemy3>().targetPos = wayPointsTest3.stations[newIndex][0];
				}
				else {
					GameObject.Destroy(this.gameObject);
				}
			}
		}

		if(this.GetComponent<wayPointForEnemy4>().enabled == true && startCrazy == true) {
			startSpawn = true;
			currectIndex = this.GetComponent<wayPointForEnemy4>().stationIndex;
			oldIndex = currectIndex;
			newIndex = currectIndex - 1;
			if(newIndex >= 0) {
				this.GetComponent<wayPointForEnemy4>().stationIndex = newIndex;
				this.GetComponent<wayPointForEnemy4>().targetPos = wayPointsTest4.stations[newIndex][0];
			}
			else {
				GameObject.Destroy(this);
			}
			startCrazy = false;
		}
		
		if(this.GetComponent<wayPointForEnemy4>().enabled == true && startCrazy == false) {
			currectIndex = this.GetComponent<wayPointForEnemy4>().stationIndex;
			if(currectIndex == oldIndex) {
				
				newIndex = currectIndex - 2;
				oldIndex = oldIndex - 1;
				
				if(newIndex >= 0) {
					this.GetComponent<wayPointForEnemy4>().stationIndex = newIndex;
					this.GetComponent<wayPointForEnemy4>().targetPos = wayPointsTest4.stations[newIndex][0];
				}
				else {
					GameObject.Destroy(this.gameObject);
				}
			}
		}

	}
}


