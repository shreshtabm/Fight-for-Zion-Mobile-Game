using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class turnForL3T6 : MonoBehaviour {
	
	Vector3 targetDir, newDir;
	public Collider[] enemyWithinSearch;
	public List <GameObject> Enemies;


	void Start () {
		searchEnemy ();
	}
	
//	void findEnemy() {
//		Enemies = new List<Transform>();
//		int range = 3000;
//		GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Enemy");
//		
//		foreach(GameObject _Enemy in ItemsInList)
//		{
//			var dist = (transform.position - _Enemy.transform.position).sqrMagnitude; 
//			if (dist < range){
//				Enemies.Add(_Enemy.transform);
//				break;
//			}   
//		}
//	}

	void searchEnemy() {
		enemyWithinSearch = Physics.OverlapSphere (this.transform.position, 300);
		if (enemyWithinSearch == null) {
			return;
		}
		for(int i = 0; i < enemyWithinSearch.Length; i++) {
			if(enemyWithinSearch[i].gameObject.tag == "Enemy") {
				Enemies.Add(enemyWithinSearch[i].gameObject);
			}
		}
	}
	
	
	void Update () {
		//searchEnemy ();

//		if (Enemies != null) {
//			targetDir = Enemies[0].transform.position - transform.position;
//			newDir = Vector3.RotateTowards (transform.forward, targetDir, 10*Time.deltaTime, 0.0F);
//			newDir.y = 0;
//			transform.rotation = Quaternion.LookRotation (newDir);
//			//this.transform.GetChild(0).gameObject.SetActive(true);
//			//this.transform.GetChild(0).gameObject.transform.rotation.z = 0;
//		}
//		else if(Enemies == null) {
//			findEnemy();
//			Debug.Log("FIND!!!!!!!!!!!!!!!");
//			//this.transform.GetChild(0).gameObject.SetActive(false);
//		}
	}

}



