using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class recycleTower : MonoBehaviour {

	public Collider[] towerWithinSearch;
	public bool ifRecycle = false;

	void Start () {

	}


	public void startRecycle() {
		resetAll ();
		searchTower ();
	}



	void resetAll() {
		ifRecycle = false;
	}

	public void searchTower() {
		towerWithinSearch = Physics.OverlapSphere (this.transform.position, 250);
		if (towerWithinSearch == null) {
			return;
		}
		for(int i = 0; i < towerWithinSearch.Length; i++) {
			if(towerWithinSearch[i].gameObject.tag == "Tower") {
				towerWithinSearch[i].gameObject.GetComponent<recycleOnTower>().setMoneyAct();
			}
		}
	}

	public void disableAllMoney() {
		this.gameObject.audio.Play();
		towerWithinSearch = Physics.OverlapSphere (this.transform.position, 250);
		if (towerWithinSearch == null) {
			return;
		}
		for(int i = 0; i < towerWithinSearch.Length; i++) {
			if(towerWithinSearch[i].gameObject.tag == "Tower") {
				towerWithinSearch[i].gameObject.GetComponent<recycleOnTower>().setMoneyGone();
			}
		}
	}



	void Update () {


	}
}

