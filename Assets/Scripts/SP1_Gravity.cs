using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SP1_Gravity : MonoBehaviour {

	public GameObject coinBar;
	public Collider[] enemyWithinSearch;
	List<GameObject> enemyList = new List<GameObject>();
	Vector3 randTargetPos;
	float threshold;


	void Start () {
		coinBar = GameObject.FindGameObjectWithTag ("CoinBar");
		searchPlane ();
		for(int i = 0; i < enemyList.Count; i++) {
			//enemyList[i].GetComponent<SampleAngent>().enabled = false;
			//enemyList[i].GetComponent<NavMeshAgent>().enabled = false;
			enemyList[i].transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
			if(enemyList[i].GetComponent<wayPointForEnemy>() != null) {
				enemyList[i].GetComponent<wayPointForEnemy>().enabled = false;
			}
			if(enemyList[i].GetComponent<wayPointForEnemy2>() != null) {
				enemyList[i].GetComponent<wayPointForEnemy2>().enabled = false;
			}
			if(enemyList[i].GetComponent<wayPointForEnemy3>() != null) {
				enemyList[i].GetComponent<wayPointForEnemy3>().enabled = false;
			}
			if(enemyList[i].GetComponent<wayPointForEnemy4>() != null) {
				enemyList[i].GetComponent<wayPointForEnemy4>().enabled = false;				
			}

		}
		threshold = 6;
	}

	void OnTriggerEnter(Collider c) {
		if(c.tag == "Enemy") {
			countDefeatForL3.defeatedEnemy++;
			GameObject.Destroy(c.gameObject);

			if(c.name == "Troll(Clone)") {
				coinBar.GetComponent<UIBarScript>().NewValue += 0.05f;
			}
			if(c.name == "Robots_Prowler(Clone)") {
				coinBar.GetComponent<UIBarScript>().NewValue += 0.1f;
			}
		}
	}

	void searchPlane() {
		enemyWithinSearch = Physics.OverlapSphere (this.transform.position, 100);
		if (enemyWithinSearch == null) {
			return;
		}
		for(int i = 0; i < enemyWithinSearch.Length; i++) {
			if(enemyWithinSearch[i].gameObject.tag == "Enemy") {
				enemyList.Add(enemyWithinSearch[i].gameObject);
			}
		}
	}

	void Update () {
		for(int i = 0; i < enemyList.Count; i++) {
			randTargetPos = new Vector3(transform.position.x, transform.position.y + Random.Range(-5, 5), transform.position.z);
			//enemyList[i].transform.position = Vector3.MoveTowards (enemyList[i].transform.position, transform.position, 80 * Time.deltaTime);
			if(enemyList[i] != null) {
				enemyList[i].transform.position = Vector3.MoveTowards (enemyList[i].transform.position, randTargetPos, 80 * Time.deltaTime);
			}
		}

		threshold -= Time.deltaTime;
		if(threshold <= 3 && threshold > 0) {
			this.GetComponent<ParticleSystem>().startSize = 5;
		}
		else if(threshold <= 0) {
			GameObject.Destroy(this.gameObject);

		}

	}
}
